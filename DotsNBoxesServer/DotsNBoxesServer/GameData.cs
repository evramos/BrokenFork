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
        /// The max players allowed in the game
        /// </summary>
        public const int MAX_PLAYERS = 2;

        /// <summary>
        /// The ID of the game
        /// </summary>
        public readonly int GameID;

        /// <summary>
        /// The publicly displayed name of this game
        /// </summary>
        public readonly string GameName;

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
        /// All of the players currently in the game
        /// </summary>
        private List<ClientData> Players = new List<ClientData>();

        /// <summary>
        /// The player that is currently playing X
        /// </summary>
        private ClientData PlayerX;

        /// <summary>
        /// Whether or not it is currently X's turn
        /// </summary>
        private bool XsTurn;

        /// <summary>
        /// The play space of the current game
        /// </summary>
        private TicTacToeBoard GameBoard;

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
                return Players.Count();
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
        public GameData(int ID, string name, string password)
        {
            GameID = ID;
            GameName = name;
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
            QueueMessage(clientAdded);

            //Add the given player to the current game
            Players.Add(playerToAdd);
            playerToAdd.CurrentGame = this;
            playerToAdd.IsInGame = true;

            //Give the new player the current count of game votes
            if(!GameInProgress)
            {
                for(int i = 0; i < StartVotes; i++)
                {
                    playerToAdd.GameQueue.Enqueue("START VOTE\r\n\r\n");
                }
            }

            //Queue a message to the client will a list of all the players currently in the game
            string playerList = "PLAYER LIST\r\n\r\n";
            foreach(ClientData currentPlayer in Players)
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
            //Reset the number of game votes
            StartVotes = 0;

            //Remove the clients access to the game
            playerToRemove.IsInGame = false;
            playerToRemove.CurrentGame = null;
            playerToRemove.GameQueue.Clear();

            //Remove the client from the game
            Players.Remove(playerToRemove);

            //Tell the other clients the player left the game
            string clientRemoved = "PLAYER LEAVE\r\n" + playerToRemove.Username + "\r\n\r\n";
            QueueMessage(clientRemoved);
        }

        /// <summary>
        /// Start the game for all the players that are currently in the lobby
        /// </summary>
        private void StartGame()
        {
            //Set the game in progress flag to true
            GameInProgress = true;

            //Create a new game board
            GameBoard = new TicTacToeBoard();

            //Send out the start game signal
            QueueMessage("GAME START\r\n\r\n");

            //Select a player to play X and send out who it is
            Random rng = new Random();
            if(rng.Next() % 2 == 0)
            {
                PlayerX = Players[0];
            }
            else
            {
                PlayerX = Players[1];
            }
            QueueMessage("PLAYERX\r\n" + PlayerX.Username + "\r\n\r\n");

            //Set the current turn to X
            XsTurn = true;
        }

        /// <summary>
        /// Queues a message to players in the current game
        /// </summary>
        /// <param name="message">The message to send to all players</param>
        public void QueueMessage(string message)
        {
            //Queue the massage for all the players that are in the game
            foreach(ClientData currentPlayer in Players)
            {
                currentPlayer.GameQueue.Enqueue(message);
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

            else if (plainRequest == "GAME VOTE" && !GameInProgress)
            {
                StartVotes++;
                QueueMessage("GAME VOTE\r\n\r\n");

                //If there have been enough start votes, start the game
                if (StartVotes >= REQUIRED_START_VOTES)
                {
                    StartGame();
                }

                return "SUCCESS\r\n\r\n";
            }

            //If the current request is to exit from the game, remove the current client from the game
            else if (plainRequest == "GAME EXIT")
            {
                this.RemovePlayer(clientInfo);
                return "SUCCESS\r\n\r\n";
            }

            //If the current request is to attempt a game move
            else if (plainRequest.StartsWith("GAME MOVE") && GameInProgress)
            {
                if((XsTurn && (clientInfo == PlayerX)) && (!XsTurn && (clientInfo != PlayerX)))
                {
                    //Parse out the tile to move on
                    int tileToAttempt = int.Parse(request.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1]);

                    //Parse out the status of the move on the given tic tac toe tile
                    TicTacToeMoveState moveStatus = GameBoard.AttemptMove(tileToAttempt, XsTurn);

                    //Return the appropriate value and queue the appropriate message
                    if(moveStatus == TicTacToeMoveState.Valid)
                    {
                        QueueMessage("MOVE " + tileToAttempt.ToString() + "\r\n\r\n");
                        return "SUCCESS\r\n\r\n";
                    }
                    else if (moveStatus == TicTacToeMoveState.Win)
                    {
                        QueueMessage("GAME FINISH\r\n" + ((clientInfo == PlayerX) ? "X" : "O") + "\r\n\r\n");
                        return "SUCCESS\r\n\r\n";
                    }
                    else if (moveStatus == TicTacToeMoveState.Cats)
                    {
                        QueueMessage("GAME FINISH\r\nCATZ\r\n\r\n");
                        return "SUCCESS\r\n\r\n";
                    }
                }
            }

            //If the client request was otherwise unhandled, return bad request
            return "BAD REQUEST\r\n\r\n";
        }
    }

    /// <summary>
    /// A single tick tac tow board
    /// </summary>
    class TicTacToeBoard
    {
        private const int BOARD_LENGTH = 3;

        /// <summary>
        /// The ticktack tow board
        /// </summary>
        private TicTacToeTileState[,] BoardContents;

        public TicTacToeBoard()
        {
            //Create a new tic tac tow board
            BoardContents = new TicTacToeTileState[BOARD_LENGTH, BOARD_LENGTH];

            //Clear the board
            for (int curCol = 0; curCol < BOARD_LENGTH; curCol++)
            {
                for (int curRow = 0; curRow < BOARD_LENGTH; curRow++)
                {
                    BoardContents[curCol, curRow] = TicTacToeTileState.None;
                }
            }
        }

        public TicTacToeMoveState AttemptMove(int tileIndex, bool X)
        {
            //Get the position of the current move
            int curCol = (tileIndex - 1) / BOARD_LENGTH;
            int curRow = (tileIndex - 1) % BOARD_LENGTH;

            //If the title at the current position is full return AlreadyFilled
            if(BoardContents[curCol, curRow] != TicTacToeTileState.None)
            {
                return TicTacToeMoveState.AlreadyFilled;
            }

            //Place the requested X or O on the requested tile
            if(X)
            {
                BoardContents[curCol, curRow] = TicTacToeTileState.X;
            }
            else
            {
                BoardContents[curCol, curRow] = TicTacToeTileState.O;
            }

            //If there is a win condition return win
            if(CheckWin())
            {
                return TicTacToeMoveState.Win;
            }

            //Check for a catz game
            bool emptyExists = false;
            for (curCol = 0; curCol < BOARD_LENGTH; curCol++)
            {
                for (curRow = 0; curRow < BOARD_LENGTH; curRow++)
                {
                    if(BoardContents[curCol, curRow] == TicTacToeTileState.None)
                    {
                        emptyExists = true;
                        break;
                    }
                }
                if(emptyExists)
                {
                    break;
                }
            }

            //Otherwise just return valid move
            return TicTacToeMoveState.Valid;
        }

        //Check to see if the board is in a win state
        private bool CheckWin()
        {
            //Check for vertical win
            for(int curCol = 0; curCol < BOARD_LENGTH; curCol++)
            {
                //Detect vertical win for the current row
                bool verticalWin = (BoardContents[curCol, 0] != TicTacToeTileState.None) && 
                    (BoardContents[curCol, 0] == BoardContents[curCol, 1]) && 
                    (BoardContents[curCol, 1] == BoardContents[curCol, 2]);

                //If there is a vertical win, return true
                if(verticalWin){ return true; }
            }

            //Check for horizontal win
            for (int curRow = 0; curRow < BOARD_LENGTH; curRow++)
            {
                //Detect horizontal win for the current row
                bool horizontalWin = (BoardContents[0, curRow] != TicTacToeTileState.None) &&
                    (BoardContents[0, curRow] == BoardContents[1, curRow]) &&
                    (BoardContents[1, curRow] == BoardContents[2, curRow]);

                //If there is a horizontal win, return true
                if (horizontalWin) { return true; }
            }


            //Check for diagonal win
            bool diagonalWin = ((BoardContents[0, 0] != TicTacToeTileState.None) &&
                (BoardContents[0, 0] == BoardContents[1, 1]) &&
                (BoardContents[1, 1] == BoardContents[2, 2])) ||
                ((BoardContents[0, 2] != TicTacToeTileState.None) &&
                (BoardContents[0, 2] == BoardContents[1, 1]) &&
                (BoardContents[1, 1] == BoardContents[0, 2]));

            //Return whether or not a win condition was ultimately found
            return diagonalWin;
        }
    }

    enum TicTacToeTileState
    {
        None,
        X,
        O
    }

    enum TicTacToeMoveState
    {
        Valid,
        AlreadyFilled,
        Win,
        Cats
    }
}
