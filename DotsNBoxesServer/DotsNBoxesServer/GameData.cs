using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsNBoxesServer
{
    class GameData
    {
        /// <summary>
        /// The number of start votes required to start a game
        /// </summary>
        private const int REQUIRED_START_VOTES = 2;

        /// <summary>
        /// The ID of the game
        /// </summary>
        public readonly int GameID;

        /// <summary>
        /// The publicly displayed name of this game
        /// </summary>
        public readonly string GameName;

        /// <summary>
        /// The max number of players that can join the game
        /// </summary>
        public readonly int MaxPlayers;

        /// <summary>
        /// The size of the game grid
        /// </summary>
        public readonly GridSize GameSize;

        /// <summary>
        /// Whether or not the game is password protected
        /// </summary>
        public readonly bool PasswordProtected;

        /// <summary>
        /// The password of the game if applicable
        /// </summary>
        private readonly string GamePassword;

        /// <summary>
        /// Whether or not the game is currently in progress
        /// </summary>
        private bool GameInProgress = false;

        /// <summary>
        /// All of the players that are actively playing in the game
        /// </summary>
        private List<ClientData> ActivePlayers = new List<ClientData>();

        /// <summary>
        /// All of the players that are currently in the lobby waiting for the game to start
        /// </summary>
        private List<ClientData> LobbyPlayers = new List<ClientData>();

        /// <summary>
        /// The number of votes to start the game
        /// </summary>
        private int StartVotes = 0;

        /// <summary>
        /// The number of players that are currently part of this game
        /// </summary>
        public int NumberOfPlayers
        {
            get
            {
                return ActivePlayers.Count() + LobbyPlayers.Count();
            }
        }

        /// <summary>
        /// Initiates a game so people can join it and play dots & boxes
        /// </summary>
        /// <param name="ID">The ID of the game</param>
        /// <param name="name">The name of the game</param>
        /// <param name="maxPlayers">The maximum players allowed to join the game</param>
        /// <param name="gridSize">The size of the grid to play the game on</param>
        /// <param name="password">The password to protect the game with</param>
        public GameData(int ID, string name, int maxPlayers, GridSize gridSize, string password)
        {
            GameID = ID;
            GameName = name;
            MaxPlayers = maxPlayers;
            GameSize = gridSize;
            PasswordProtected = (password != null);
            GamePassword = password;
        }

        /// <summary>
        /// Adds a given player to the current game if the proper password is provided
        /// </summary>
        /// <param name="playerToAdd">The information about the player to add</param>
        /// <param name="password">The password to join the game with</param>
        /// <returns>True if the player was added, false otherwise</returns>
        public bool AddPlayer(ClientData playerToAdd, string password)
        {
            //If the current game is password protected and the password is wrong, return false
            if (PasswordProtected && password != GamePassword)
            {
                return false;
            }

            //Queue a message to all players stating a new player has joined
            string clientAdded = "PLAYER ADDED\r\n" + playerToAdd.Username + "\r\n\r\n";
            QueueMessage(clientAdded, true);

            //Add the given player to the current game
            LobbyPlayers.Add(playerToAdd);
            playerToAdd.CurrentGame = this;
            playerToAdd.IsInGame = true;

            //Queue a message to the client to let them know if the game is in progress
            if(GameInProgress)
            {
                playerToAdd.GameQueue.Enqueue("GAME PLAYING\r\n\r\n");
            }
            else
            {
                playerToAdd.GameQueue.Enqueue("GAME WAITING\r\n\r\n");

                //Also send the player the current number of start votes
                for(int i = 0; i < StartVotes; i++)
                {
                    playerToAdd.GameQueue.Enqueue("START VOTE\r\n\r\n");
                }
            }

            //Queue a message to the client will a list of all the players currently in the game
            string playerList = "PLAYER LIST\r\n\r\n";
            foreach(ClientData currentPlayer in ActivePlayers)
            {
                playerList += "true," + currentPlayer.Username + "\r\n";
            }
            foreach(ClientData currentPlayer in LobbyPlayers)
            {
                playerList += "false," + currentPlayer.Username + "\r\n";
            }
            playerList += "\r\n";
            playerToAdd.GameQueue.Enqueue(playerList);

            //The player was added successfully return true
            return true;
        }

        /// <summary>
        /// Removes a given player from the current game
        /// </summary>
        /// <param name="playerToRemove">The information of the player to remove</param>
        public void RemovePlayer(ClientData playerToRemove)
        {
            //Remove the clients access to the game
            playerToRemove.IsInGame = false;
            playerToRemove.CurrentGame = null;
            playerToRemove.GameQueue.Clear();

            //Remove the client from the game
            if(GameInProgress && ActivePlayers.Contains(playerToRemove))
            {
                ActivePlayers.Remove(playerToRemove);
            }
            else
            {
                LobbyPlayers.Remove(playerToRemove);
            }

            //Tell the other clients the player left the game
            string clientRemoved = "PLAYER LEAVE\r\n" + playerToRemove.Username + "\r\n\r\n";
            QueueMessage(clientRemoved, true);
        }

        /// <summary>
        /// Start the game for all the players that are currently in the lobby
        /// </summary>
        private void StartGame()
        {
            //Move all of the players in the lobby to the active players list
            int playerCount = LobbyPlayers.Count;
            for (int curPlayer = 0; curPlayer < playerCount; curPlayer++)
            {
                ActivePlayers.Add(LobbyPlayers[0]);
                LobbyPlayers.RemoveAt(0);
            }

            //Set the game in progress flag to true
            GameInProgress = true;

            //Send out the start game signal
            QueueMessage("GAME START\r\n\r\n", false);
        }

        /// <summary>
        /// Queues a message to players in the current game
        /// </summary>
        /// <param name="message">The message to send to all players</param>
        /// <param name="allPlayers">Whether or not this massage should include players in the lobby</param>
        public void QueueMessage(string message, bool allPlayers)
        {
            //Queue the massage for all the players that are actively in game
            foreach(ClientData currentPlayer in ActivePlayers)
            {
                currentPlayer.GameQueue.Enqueue(message);
            }

            //If requested, also queue the message for all the players in the lobby
            if(allPlayers)
            {
                foreach(ClientData currentPlayer in LobbyPlayers)
                {
                    currentPlayer.GameQueue.Enqueue(message);
                }
            }
        }

        public string ProcessRequest(string request, ClientData clientInfo)
        {
            //Remove the "\r\n\r\n" from the request
            string plainRequest = request.Substring(0, request.Length - 4);

            //If the current request is a ping, respond from the game queue or with pong
            if (plainRequest == "PING")
            {
                //If there are items in the game queue, dequeue one and send it to the client
                if (clientInfo.GameQueue.Count > 0)
                {
                    return clientInfo.GameQueue.Dequeue();
                }

                //Otherwise return "PONG"
                else
                {
                    return "PONG\r\n\r\n";
                }
            }

            else if (plainRequest == "GAME VOTE")
            {
                if (!GameInProgress)
                {
                    StartVotes++;
                    QueueMessage("GAME VOTE\r\n\r\n", true);

                    //If there have been enough start votes, start the game
                    if (StartVotes >= REQUIRED_START_VOTES)
                    {
                        StartGame();
                    }

                    return "SUCCESS\r\n\r\n";
                }
            }

            //If the current request is to exit from the game, remove the current client from the game
            else if (plainRequest == "GAME EXIT")
            {
                this.RemovePlayer(clientInfo);
                return "SUCCESS\r\n\r\n";
            }

            //If the client request was otherwise unhandled, return bad request
            return "BAD REQUEST\r\n\r\n";
        }
    }

    /// <summary>
    /// An enumeration of the allowable grid sizes
    /// </summary>
    enum GridSize
    {
        FourByFour,
        SixBySix,
        EightByEight
    }
}
