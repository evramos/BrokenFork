using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DotsNBoxesServer
{
    /// <summary>
    /// A class containing data about the current client
    /// </summary>
    class ClientData
    {
        /// <summary>
        /// The ID of the client
        /// </summary>
        public readonly int ClientID;

        /// <summary>
        /// Whether or not the client has signed into an authenticated user account
        /// </summary>
        public bool IsAuthenticated = false;

        /// <summary>
        /// The username of the client
        /// </summary>
        public string Username = "";

        /// <summary>
        /// Whether or not the client is currently in a game
        /// </summary>
        public bool IsInGame = false;

        /// <summary>
        /// The game the player is currently in
        /// </summary>
        public GameData CurrentGame;

        /// <summary>
        /// The queue of messages to send to the client from the current game
        /// </summary>
        public Queue<string> GameQueue = new Queue<string>();

        /// <summary>
        /// The RSA to use for the clients password transmissions
        /// </summary>
        public RSACryptoServiceProvider RSA;

        /// <summary>
        /// Initiates a client with an ID
        /// </summary>
        /// <param name="ID">The ID to create the client with</param>
        public ClientData(int ID)
        {
            ClientID = ID;
        }

        /// <summary>
        /// Returns the identifier that best represents the client
        /// </summary>
        /// <returns></returns>
        public string GetBestID()
        {
            //If the client is authenticated, return their username
            if(IsAuthenticated)
            {
                return Username;
            }

            //Otherwise return their server given ID
            else
            {
                return ClientID.ToString();
            }
        }
    }
}
