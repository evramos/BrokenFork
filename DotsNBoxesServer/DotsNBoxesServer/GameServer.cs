using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace DotsNBoxesServer
{
    class GameServer
    {
        /// <summary>
        /// Whether or not the server is currently listening
        /// </summary>
        private bool ServerListening = false;

        /// <summary>
        /// The current settings of this game server
        /// </summary>
        private ServerSettings CurrentServerSettings;

        /// <summary>
        /// The ID to set the next client to
        /// </summary>
        private int NextClientID = 0;

        /// <summary>
        /// A list of all the currently connected clients
        /// </summary>
        private List<ClientData> ConnectedClients = new List<ClientData>();

        /// <summary>
        /// Creates a game server with given settings
        /// </summary>
        /// <param name="serverSettings">The settings to run the game server with</param>
        public GameServer(ServerSettings serverSettings)
        {
            CurrentServerSettings = serverSettings;
        }

        /// <summary>
        /// Starts the game server. Listens for clients and creates individual threads for them
        /// NOTE: Blocks until the server is finished
        /// </summary>
        public void StartServer()
        {
            //If the server is already listening, throw an exception
            if(ServerListening)
            {
                throw new Exception("Server is already listening");
            }

            //Get the endpoint information of the local computer
            IPHostEntry localHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress localIPAddress = localHostInfo.AddressList.First((curAddr => curAddr.AddressFamily == AddressFamily.InterNetwork));
            IPEndPoint localEndPoint = new IPEndPoint(localIPAddress, CurrentServerSettings.Port);

            //Create a TCPListener
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Bind the listener to the local endpoint
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(CurrentServerSettings.MaxClients);
            }
            catch
            {
                Console.WriteLine("Unable to bind listener to localhost");
                return;
            }

            //Start listening for connections
            while(true)
            {
                //Listen for a new client
                Console.WriteLine("Listener: Ready");
                Socket clientSocket = listener.Accept();

                //Create a thread for the client that just connected
                ClientData newClientData = new ClientData(NextClientID++);
                Thread newClientThread = new Thread(new ThreadStart(() => ClientThread(clientSocket, newClientData)));
                newClientThread.Start();
            }
        }

        /// <summary>
        /// Contains a client service loop
        /// </summary>
        /// <param name="clientSocket">The socket to talk to the client with</param>
        /// <param name="clientInfo">The information about the client</param>
        public void ClientThread(Socket clientSocket, ClientData clientInfo)
        {
            //Print a message stating this client has connected
            Console.WriteLine("Client Connected: " + clientInfo.GetBestID());
            
            //Actively handle client requests
            while(true)
            {
                //Read in the clients next request
                string currentRequest = "";
                while(true)
                {
                    //Attempt to receive from the client
                    byte[] readBuffer = new byte[CurrentServerSettings.PacketBufferSize];
                    int bytesRead;
                    try
                    {
                        bytesRead = clientSocket.Receive(readBuffer);
                    }
                    catch
                    {
                        bytesRead = 0;
                    }

                    //If no bytes were read the client disconnected, kill the current thread
                    if(bytesRead == 0)
                    {
                        clientSocket.Close();
                        Console.WriteLine("Client Disconnected: " + clientInfo.GetBestID());
                        return;
                    }

                    //Append the part of the request we just read to the overall request
                    currentRequest += Encoding.UTF8.GetString(readBuffer);

                    //If we have reached the end of the request, break out of the receive loop
                    if(currentRequest.Contains("\r\n\r\n"))
                    {
                        currentRequest = currentRequest.Substring(0, currentRequest.IndexOf('\0'));
                        break;
                    }
                }

                //If the client is not in a game process their request using the request parser
                if(!clientInfo.IsInGame)
                {
                    //Process the clients request
                    string serverResponce;
                    try
                    {
                        serverResponce = ProcessRequest(currentRequest, clientInfo);
                    }
                    catch
                    {
                        serverResponce = CurrentServerSettings.VersionNumber.ToString() + " UKNOWN, BAD REQUEST\r\n\r\n";
                    }

                    //Convert the response into bytes and send it to the client
                    byte[] responce = Encoding.UTF8.GetBytes(serverResponce);
                    clientSocket.Send(responce);
                }

                //Otherwise pass the user request off to their game object
                else
                {
                    throw new NotImplementedException("Game code unimplemented");
                }
                
                
            }
        }

        /// <summary>
        /// Processes a non-in-game client request
        /// </summary>
        /// <param name="reuqest">The request provided by the client</param>
        /// <param name="clientInfo">The clients information object</param>
        /// <returns>A response to send to the client</returns>
        public string ProcessRequest(string reuqest, ClientData clientInfo)
        {
            //Read in the header of the clients request
            string[] requestHeader = reuqest.Substring(0, reuqest.IndexOf("\r\n")).Split(' ');

            //If the request does not have at least two parts, immediately return bad request
            if(requestHeader.Length < 2)
            {
                //Tell whoever is monitoring the console that the current client made a bad request
                Console.WriteLine("Client " + clientInfo.GetBestID() + ": BAD REQUEST");

                //Return a bad request response
                return CurrentServerSettings.VersionNumber.ToString() + ", BAD REQUEST\r\n\r\n";
            }

            //Tell whoever is monitoring the console that the current client made a request
            Console.WriteLine("Client " + clientInfo.GetBestID() + ": " + requestHeader[0] + " " + requestHeader[1]);

            //Start the client response
            string currentResponse = CurrentServerSettings.VersionNumber.ToString() + " " + requestHeader[0] +
                " " + requestHeader[1] + ", OK\r\n";

            //If the user request starts with "UTILITIES", process the second part of the request as a utility
            if (requestHeader[0] == "UTILITIES")
            {
                //If the requested utility is just version check, simply close the client response since it already includes version
                if (requestHeader[1] == "VERSIONCHECK")
                {
                    currentResponse += "\r\n";
                }

                //If the requested utility is RSA, setup RSA for the current client and give them a public key
                else if (requestHeader[1] == "RSA")
                {
                    //If the client does not already have RSA setup, setup RSA for the client
                    if(clientInfo.RSA == null)
                    {
                        clientInfo.RSA = new RSACryptoServiceProvider(2048);
                    }

                    //Add the RSA public key to the response and end the response
                    currentResponse += clientInfo.RSA.ToXmlString(false) + "\r\n\r\n";
                }

                //If the seconds part of the request is not a valid utility, return a "BAD REQUEST" response
                else
                {
                    currentResponse = currentResponse.Replace("OK", "BAD REQUEST\r\n");
                }
            }

            //If the user request starts with "USER", process the second part of the request as a user account option
            else if (requestHeader[0] == "USER")
            {
                //If the requested user account option is check name, check if the requested username is available
                if (requestHeader[1] == "CHECKNAME")
                {
                    //Extract the username to check from the request
                    int usernameStart  = reuqest.IndexOf("\r\n") + 2;
                    int usernameLength = reuqest.IndexOf("\r\n\r\n") - usernameStart;
                    string username = reuqest.Substring(usernameStart, usernameLength);

                    //Use the UserDatabase utility to check availability
                    string usernameCheck = UserDatabase.CheckAvailable(username);

                    //Add the username check response to the current response and end the response
                    currentResponse += usernameCheck + "\r\n\r\n";
                }

                //If the requested user account option is create, create a user account and login the user
                else if (requestHeader[1] == "CREATE")
                {
                    //If the client has RSA setup attempt to create an account with the information provided
                    if(clientInfo.RSA != null)
                    {
                        //Parse out the username and password provided by the client
                        string[] requestLines = reuqest.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                        string username = requestLines[1];
                        byte[] encryptedPassword = Convert.FromBase64String(requestLines[2]);
                        byte[] decryptedPassword = clientInfo.RSA.Decrypt(encryptedPassword, false);
                        string password = Encoding.UTF8.GetString(decryptedPassword);

                        //Use the UserDatabase utility to create a user account
                        string accountCreate = UserDatabase.CreateAccount(username, password, clientInfo);

                        //Add the account create response to the response and end the response
                        currentResponse += accountCreate + "\r\n\r\n";
                    }

                    //Otherwise return an error message
                    else
                    {
                        currentResponse += "SETUP RSA FIRST\r\n\r\n";
                    }
                }

                //If the requested user account option is authenticate, attempt to authenticate the user
                else if (requestHeader[1] == "AUTHENTICATE")
                {
                    //If the client has RSA setup attempt to authenticate them
                    if (clientInfo.RSA != null)
                    {
                        //Parse out the username and password provided by the client
                        string[] requestLines = reuqest.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        string username = requestLines[1];
                        byte[] encryptedPassword = Convert.FromBase64String(requestLines[2]);
                        byte[] decryptedPassword = clientInfo.RSA.Decrypt(encryptedPassword, false);
                        string password = Encoding.UTF8.GetString(decryptedPassword);

                        //Use the UserDatabase utility to authenticate the user account
                        string accountAuthenticate = UserDatabase.AuthenticateAccount(username, password, clientInfo);

                        //Add the authentication response and end the response
                        currentResponse += accountAuthenticate + "\r\n\r\n";
                    }

                    //Otherwise return an error message
                    else
                    {
                        currentResponse += "SETUP RSA FIRST\r\n\r\n";
                    }
                }

                //If the requested user account option is delete, authenticate and delete the user account
                else if (requestHeader[1] == "DELETE")
                {
                    //If the client has RSA setup attempt to authenticate them
                    if (clientInfo.RSA != null)
                    {
                        //Parse out the username and password provided by the client
                        string[] requestLines = reuqest.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        string username = requestLines[1];
                        byte[] encryptedPassword = Convert.FromBase64String(requestLines[2]);
                        byte[] decryptedPassword = clientInfo.RSA.Decrypt(encryptedPassword, false);
                        string password = Encoding.UTF8.GetString(decryptedPassword);

                        //Use the UserDatabase utility to authenticate and delete the user account
                        string accountDelete = UserDatabase.DeleteAccount(username, password, clientInfo);

                        //Add the delete response and end the response
                        currentResponse += accountDelete + "\r\n\r\n";
                    }

                    //Otherwise return an error message
                    else
                    {
                        currentResponse += "SETUP RSA FIRST\r\n\r\n";
                    }
                }

                //If the seconds part of the request is not a valid user account option, return a "BAD REQUEST" response
                else
                {
                    currentResponse = currentResponse.Replace("OK", "BAD REQUEST\r\n");
                }
            }

            //If the user request starts with "GAME", process the second part of the request as a game utility
            else if (requestHeader[0] == "GAME")
            {
                //
                if (requestHeader[1] == "LIST")
                {

                }

                //
                else if (requestHeader[1] == "CREATE")
                {

                }

                //
                else if (requestHeader[1] == "JOIN")
                {

                }

                //
                else if (requestHeader[1] == "EXIT")
                {

                }

                //If the seconds part of the request is not a valid game utility, return a "BAD REQUEST" response
                else
                {
                    currentResponse = currentResponse.Replace("OK", "BAD REQUEST\r\n");
                }
            }

            //If the first part of the request is bogus, return a "BAD REQUEST" response
            else
            {
                currentResponse = currentResponse.Replace("OK", "BAD REQUEST\r\n");
            }

            //Return the response we just built
            return currentResponse;
        }
    }
}
