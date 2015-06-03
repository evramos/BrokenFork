using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace DotsNBoxes
{
    static class GameServer
    {
        /// <summary>
        /// The server versions that are supported by this client
        /// </summary>
        private static float[] SupportedVersions = { 1.0f };

        /// <summary>
        /// The default port to connect to the server on
        /// </summary>
        private const int DEAFULT_PORT = 3000;

        /// <summary>
        /// The size of the packet read buffer
        /// </summary>
        private const int PACKET_BUFFER_SIZE = 1460;

        /// <summary>
        /// The length of game names plus their lock status
        /// </summary>
        private const int GAME_NAME_LENGTH = 27;

        /// <summary>
        /// The socket to communicate with the game server on
        /// </summary>
        private static Socket serverSocket;

        /// <summary>
        /// The RSA to encrypt passwords being sent to the server with
        /// </summary>
        private static RSACryptoServiceProvider rsaEncryption;

        #region Server Utilities

        /// <summary>
        /// Connects to a game server at a given address
        /// </summary>
        /// <param name="serverAddress">The address of the game server to connect to</param>
        /// <returns>The status of the connection to the game server</returns>
        public static ConnectionResponse Connect(string serverAddress)
        {
            try
            {
                //Split the server name from the port number
                string[] serverAddressSplit = serverAddress.Split(':');

                //Get the servers name
                string serverName = serverAddressSplit[0];

                //Get the servers port
                int serverPort = DEAFULT_PORT;
                if(serverAddressSplit.Length > 1)
                {
                    int.TryParse(serverAddressSplit[1], out serverPort);
                }

                //Get the endpoint information of the server
                IPHostEntry serverHostInfo = Dns.GetHostEntry(serverName);
                IPAddress serverIPAddress = serverHostInfo.AddressList.First((curAddr => curAddr.AddressFamily == AddressFamily.InterNetwork));
                IPEndPoint serverEndPoint = new IPEndPoint(serverIPAddress, serverPort);

                //Connect to the game server
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Connect(serverEndPoint);

                //Ask the server what version it is running
                string getVersion = "UTILITIES VERSIONCHECK\r\n\r\n";
                serverSocket.Send(Encoding.UTF8.GetBytes(getVersion));

                //Read in the server's response
                string versionResponse = ServerRead();

                //Parse the protocol version from the server
                float protocalVersion = float.Parse(versionResponse.Substring(0, versionResponse.IndexOf(' ')));

                //If the server protocol is not supported, return wrong version
                if(!SupportedVersions.Contains(protocalVersion))
                {
                    return ConnectionResponse.WrongVersion;
                }
            }
            catch
            {
                return ConnectionResponse.UnableToConnect;
            }

            //The server is all connected, return a positive response
            return ConnectionResponse.Connected;
        }

        /// <summary>
        /// Initiates client side RSA using a public key provided by the server
        /// </summary>
        /// <returns>True if RSA is successfully setup; false otherwise</returns>
        public static bool InitiateRSA()
        {
            //If RSA is already setup, return true
            if(rsaEncryption != null)
            {
                return true;
            }

            //Ask the server for an RSA public key
            string getRSA = "UTILITIES RSA\r\n\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(getRSA));

            //Read in the server's response
            string rsaResponse = ServerRead();

            //If the RSA response is not okay, return false
            if (!ResponceIsOkay(rsaResponse))
            {
                return false;
            }

            //Attempt to create an RSA provider using the info from the server
            try
            {
                //Parse out the RSA XML from the server
                int publicKeyStart = rsaResponse.IndexOf("\r\n") + 2;
                string publicKey = rsaResponse.Substring(publicKeyStart, (rsaResponse.Length - 4) - publicKeyStart);

                //Create a new RSA service provider with the public key from the server
                rsaEncryption = new RSACryptoServiceProvider(2048);
                rsaEncryption.FromXmlString(publicKey);
            }
            catch
            {
                //Something when wrong while parsing... return false
                return false;
            }

            //RSA is not setup, return true
            return true;
        }

        #endregion

        #region User Account Utilities

        /// <summary>
        /// Checks to see if a given username is available on the server
        /// </summary>
        /// <param name="username">The username to check</param>
        /// <returns>The response given by the server</returns>
        public static UserResponse CheckUsernameAvailability(string username)
        {
            //Ask the server if the given username is available
            string checkUsername = "USER CHECKNAME\r\n" + username + "\r\n\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(checkUsername));

            //Read in the server's response
            string usernameResponse = ServerRead();

            //If the username response is not okay, return false
            if (!ResponceIsOkay(usernameResponse))
            {
                return UserResponse.Error;
            }

            //Parse out the username message
            int usernameMessageStart = usernameResponse.IndexOf("\r\n") + 2;
            string usernameMessage = usernameResponse.Substring(usernameMessageStart, (usernameResponse.Length - 4) - usernameMessageStart);
            
            //Interpret the account create message
            return SeverResponseToUserResponce(usernameMessage);
        }

        /// <summary>
        /// Asks the server to create an account with a given username and password
        /// </summary>
        /// <param name="username">The username to create the new account with</param>
        /// <param name="password">The password to create the new account with</param>
        /// <returns>The status of the new account</returns>
        public static UserResponse CreateAccount(string username, string password)
        {
            //Attempt to setup RSA
            bool validRSA = InitiateRSA();

            //If unable to setup RSA return error
            if (!validRSA)
            {
                return UserResponse.Error;
            }

            //Encrypt the provided password with RSA
            byte[] plaintextPassword = Encoding.UTF8.GetBytes(password);
            byte[] encryptedPassword = rsaEncryption.Encrypt(plaintextPassword, false);
            string passwordToSend = Convert.ToBase64String(encryptedPassword);

            //Ask the server to create an account for us
            string userCreate = "USER CREATE\r\n" + username + "\r\n" + passwordToSend + "\r\n\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(userCreate));

            //Read in the server's response
            string createAccountResponse = ServerRead();

            //If the create account response is not okay, return false
            if (!ResponceIsOkay(createAccountResponse))
            {
                return UserResponse.Error;
            }

            //Parse out the account creation response
            int userCreateMessageStart = createAccountResponse.IndexOf("\r\n") + 2;
            string usernameMessage = createAccountResponse.Substring(userCreateMessageStart, (createAccountResponse.Length - 4) - userCreateMessageStart);

            //Interpret the account create message
            return SeverResponseToUserResponce(usernameMessage);
        }

        /// <summary>
        /// Asks the server to login to a given account
        /// </summary>
        /// <param name="username">The username of the account to login to</param>
        /// <param name="password">The password to attempt to login with</param>
        /// <returns>The status of the account login</returns>
        public static UserResponse Login(string username, string password)
        {
            //Attempt to setup RSA
            bool validRSA = InitiateRSA();

            //If unable to setup RSA return error
            if (!validRSA)
            {
                return UserResponse.Error;
            }

            //Encrypt the provided password with RSA
            byte[] plaintextPassword = Encoding.UTF8.GetBytes(password);
            byte[] encryptedPassword = rsaEncryption.Encrypt(plaintextPassword, false);
            string passwordToSend = Convert.ToBase64String(encryptedPassword);

            //Ask the server to authenticate our account for us
            string userAuthenticate = "USER AUTHENTICATE\r\n" + username + "\r\n" + passwordToSend + "\r\n\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(userAuthenticate));

            //Read in the server's response
            string authenticateResponse = ServerRead();

            //If the authenticate account response is not okay, return false
            if (!ResponceIsOkay(authenticateResponse))
            {
                return UserResponse.Error;
            }

            //Parse out the account authentication response
            int authenticationMessageStart = authenticateResponse.IndexOf("\r\n") + 2;
            string authenticationMessage = authenticateResponse.Substring(authenticationMessageStart, (authenticateResponse.Length - 4) - authenticationMessageStart);

            //Interpret the account authenticate message
            return SeverResponseToUserResponce(authenticationMessage);
        }

        /// <summary>
        /// Asks the server to delete a user account
        /// </summary>
        /// <param name="username">The username of the account to delete</param>
        /// <param name="password">The password to attempt to delete the account with</param>
        /// <returns>The status of the account deletion</returns>
        public static UserResponse DeleteAccount(string username, string password)
        {
            //Attempt to setup RSA
            bool validRSA = InitiateRSA();

            //If unable to setup RSA return error
            if (!validRSA)
            {
                return UserResponse.Error;
            }

            //Encrypt the provided password with RSA
            byte[] plaintextPassword = Encoding.UTF8.GetBytes(password);
            byte[] encryptedPassword = rsaEncryption.Encrypt(plaintextPassword, false);
            string passwordToSend = Convert.ToBase64String(encryptedPassword);

            //Ask the server to delete our account for us
            string userDelete = "USER DELETE\r\n" + username + "\r\n" + passwordToSend + "\r\n\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(userDelete));

            //Read in the server's response
            string deleteResponse = ServerRead();

            //If the delete account response is not okay, return false
            if (!ResponceIsOkay(deleteResponse))
            {
                return UserResponse.Error;
            }

            //Parse out the account delete response
            int deleteMessageStart = deleteResponse.IndexOf("\r\n") + 2;
            string deleteMessage = deleteResponse.Substring(deleteMessageStart, (deleteResponse.Length - 4) - deleteMessageStart);

            //Interpret the account delete message
            return SeverResponseToUserResponce(deleteMessage);
        }

        #endregion

        #region Game Utilites (Pre-lobby)

        /// <summary>
        /// Asks the server for a list of available games
        /// </summary>
        /// <returns>A list of games ready to join</returns>
        public static List<ListItem> ListGames()
        {
            //Ask the server to list all of the games
            string listGames = "GAME LIST\r\n\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(listGames));

            //Read in the server's response
            string gameList = ServerRead();

            //If the game list response is not okay, return null
            if (!ResponceIsOkay(gameList))
            {
                return null;
            }

            //Split the game list at each new line
            string[] gameLines = gameList.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            //If there is not at least one game return null
            if(gameLines.Length < 2)
            {
                return null;
            }

            //Generate a list of the games sent to us by the server
            List<ListItem> gameListItems = new List<ListItem>();
            for(int curGame = 1; curGame < gameLines.Length; curGame++)
            {
                //Split the current game line into information about the current game
                string[] gameInfo = gameLines[curGame].Split(',');

                //Parse out a server game object from the information provided by the server
                ServerGame gameToAdd = new ServerGame()
                {
                    ID = int.Parse(gameInfo[0]),
                    Name = gameInfo[1],
                    IsFull = (ServerGame.MAX_PLAYERS - int.Parse(gameInfo[2]) <= 0),
                    PassProtected = bool.Parse(gameInfo[3])
                };

                //Generate list text for the current game
                string listText = (gameToAdd.PassProtected ? "(L)" : "(O)") + " " + gameToAdd.Name;
                while(listText.Length < GAME_NAME_LENGTH) { listText += " "; }
                listText += "         " + gameInfo[2] + "/" + ServerGame.MAX_PLAYERS;

                //Add the current game to the list of games
                ListItem newGame = new ListItem()
                {
                    Text = listText,
                    Value = gameToAdd
                };
                gameListItems.Add(newGame);
            }

            //Return the list of games we just generated
            return gameListItems;
        }

        /// <summary>
        /// Asks the server to create a game
        /// </summary>
        /// <param name="name">The name to create the game with</param>
        /// <param name="maxPlayers">The player cap to create the game with</param>
        /// <param name="gameSize">The grid size to create the game with</param>
        /// <param name="passwordProtect">Whether or not the game should be password protected</param>
        /// <param name="password">The password to create the game with (if applicable)</param>
        /// <returns>Whether or not the game got created properly</returns>
        public static bool CreateGame(string name, bool passwordProtect, string password)
        {
            string enryptedPasswordText = "";
            if(passwordProtect)
            {
                //Attempt to setup RSA
                bool validRSA = InitiateRSA();

                //If unable to setup RSA return error
                if (!validRSA)
                {
                    return false;
                }

                //Encrypt the provided password with RSA
                byte[] plaintextPassword = Encoding.UTF8.GetBytes(password);
                byte[] encryptedPassword = rsaEncryption.Encrypt(plaintextPassword, false);
                enryptedPasswordText = Convert.ToBase64String(encryptedPassword);
            }

            //Ask the server to create a game
            string gameCreate = "GAME CREATE\r\n" + name + "\r\n" + (passwordProtect ? enryptedPasswordText + "\r\n" : "") + "\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(gameCreate));

            //Read in the server's response
            string gameCreateStatus = ServerRead();

            //If the game list response is not okay, return null
            if (!ResponceIsOkay(gameCreateStatus))
            {
                return false;
            }

            //Return whether or not creating the game was successful
            string response = gameCreateStatus.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1];
            return (response == "SUCCESS");
        }

        /// <summary>
        /// Asks the server to join a game
        /// </summary>
        /// <param name="gameToJoin">The game on the server to join</param>
        /// <param name="password">The password of the game to join</param>
        /// <returns>The status of joining the game</returns>
        public static GameResponse JoinGame(ServerGame gameToJoin, string password)
        {
            //If not password was provided, send "NOPASS"
            if(string.IsNullOrEmpty(password))
            {
                password = "NOPASS";
            }
            
            //Attempt to setup RSA
            bool validRSA = InitiateRSA();

            //If unable to setup RSA return error
            if (!validRSA)
            {
                return GameResponse.Error;
            }

            //Encrypt the provided password with RSA
            byte[] plaintextPassword = Encoding.UTF8.GetBytes(password);
            byte[] encryptedPassword = rsaEncryption.Encrypt(plaintextPassword, false);
            string enryptedPasswordText = Convert.ToBase64String(encryptedPassword);

            //Ask the server to create a game
            string gameJoin = "GAME JOIN\r\n" + gameToJoin.ID + "\r\n" + enryptedPasswordText + "\r\n\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(gameJoin));

            //Read in the server's response
            string gameJoinStatus = ServerRead();

            //If the game list response is not okay, return null
            if (!ResponceIsOkay(gameJoinStatus))
            {
                return GameResponse.Error;
            }

            //Return whatever the server told us
            string response = gameJoinStatus.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1];
            if (response == "SUCCESS")
            {
                return GameResponse.Success;
            }
            else if(response == "INCORRECT PASSWORD")
            {
                return GameResponse.InvalidPassword;
            }
            else if(response == "GAME FULL")
            {
                return GameResponse.GameFull;
            }
            else
            {
                return GameResponse.Error;
            }
        }

        #endregion

        #region Game Utilities (Post-lobby)

        /// <summary>
        /// Asks the server to exit the current game
        /// </summary>
        public static bool ExitGame()
        {
            //Ask the server to list all of the games
            string exitGame = "GAME EXIT\r\n\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(exitGame));

            //Read in the server's response
            string gameExitStatus = ServerRead();

            //Return whether or not the exit was successful
            return gameExitStatus == "SUCCESS\r\n\r\n";
        }

        /// <summary>
        /// Pings the game server for a game update
        /// </summary>
        /// <returns>The servers response to the ping</returns>
        public static string GamePing()
        {
            //Ping the server
            string exitGame = "PING\r\n\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(exitGame));

            //Return the servers response to the ping
            return ServerRead();
        }

        /// <summary>
        /// Pings the game server for a game update
        /// </summary>
        /// <returns>The servers response to the ping</returns>
        public static string GameVote()
        {
            //Ping the server
            string exitGame = "GAME VOTE\r\n\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(exitGame));

            //Return the servers response to the ping
            return ServerRead();
        }

        /// <summary>
        /// Asks the server to perform a move on a given tile
        /// </summary>
        /// <param name="move">The tile to move on</param>
        public static void GameMove(string move)
        {
            //Ping the server
            string gameMove = "GAME MOVE\r\n" + move + "\r\n\r\n";
            serverSocket.Send(Encoding.UTF8.GetBytes(gameMove));

            //Return the servers response to game move
            ServerRead();
        }

        #endregion

        /// <summary>
        /// Reads a single response from the server
        /// </summary>
        /// <returns>The response read from the server</returns>
        private static string ServerRead()
        {
            //Read the response from the server
            string serverResponse = "";
            while (true)
            {
                //Attempt to receive from the client
                byte[] readBuffer = new byte[PACKET_BUFFER_SIZE];
                int bytesRead = serverSocket.Receive(readBuffer);

                //If no bytes were read the client disconnected, kill the current thread
                if (bytesRead == 0)
                {
                    serverSocket.Close();
                    break;
                }

                //Append the part of the request we just read to the overall request
                serverResponse += Encoding.UTF8.GetString(readBuffer);

                //If we have reached the end of the request, break out of the receive loop
                if (serverResponse.Contains("\r\n\r\n"))
                {
                    serverResponse = serverResponse.Substring(0, serverResponse.IndexOf('\0'));
                    break;
                }
            }

            //Return the response provided by the server
            return serverResponse;
        }

        /// <summary>
        /// Determines if the message in the header of a given response is "OK"
        /// </summary>
        /// <param name="string response"></param>
        /// <returns>True if the response message is "OK"; false otherwise</returns>
        private static bool ResponceIsOkay(string response)
        {
            //Find the start and end of the response message
            int responseMessageStart = response.IndexOf(',') + 2;
            int responseMessageEnd = response.IndexOf("\r\n");

            //Parse out the response message
            string responseMessage = response.Substring(responseMessageStart, responseMessageEnd - responseMessageStart);

            //Return true if the response message is "OK", otherwise return false
            return responseMessage == "OK";
        }

        /// <summary>
        /// Converts a server response string to a user response enum
        /// </summary>
        /// <param name="serverResponce">The server response to convert</param>
        /// <returns>The server response in the form of a user response</returns>
        private static UserResponse SeverResponseToUserResponce(string serverResponce)
        {
            if (serverResponce == "USERNAME INVALID")
            {
                return UserResponse.UsernameInvalid;
            }
            else if (serverResponce == "USERNAME TAKEN")
            {
                return UserResponse.UsernameTaken;
            }
            else if (serverResponce == "USERNAME AVAILABLE")
            {
                return UserResponse.UsernameAvailable;
            }
            else if (serverResponce == "SUCCESS")
            {
                return UserResponse.Success;
            }
            else if (serverResponce == "AUTHENTICATION FAILED")
            {
                return UserResponse.AuthenticationFailed;
            }
            else
            {
                return UserResponse.Error;
            }
        }
    }

    /// <summary>
    /// Represents a single list box item
    /// </summary>
    class ListItem
    {
        /// <summary>
        /// The text to display in the listbox
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// The value of the textbox
        /// </summary>
        public object Value { get; set; }
    }

    /// <summary>
    /// All of the possible responses when connecting to a server
    /// </summary>
    enum ConnectionResponse
    {
        Connected,
        WrongVersion,
        UnableToConnect
    }

    /// <summary>
    /// All of the possible responses when querying for account information
    /// </summary>
    enum UserResponse
    {
        UsernameInvalid,
        UsernameTaken,
        UsernameAvailable,
        Success,
        AuthenticationFailed,
        Error
    }

    enum GameResponse
    {
        Success,
        InvalidPassword,
        GameFull,
        Error
    }
}
