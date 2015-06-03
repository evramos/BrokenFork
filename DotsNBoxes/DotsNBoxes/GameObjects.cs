using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsNBoxes
{
    /// <summary>
    /// Represents a single game on the server
    /// </summary>
    class ServerGame
    {
        /// <summary>
        /// The max number of players that can be in a server game
        /// </summary>
        public const int MAX_PLAYERS = 2;

        /// <summary>
        /// The ID of the game on the server
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The name of the game
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether or not the game is full
        /// </summary>
        public bool IsFull { get; set; }

        /// <summary>
        /// Whether or not the game can be joined without a password
        /// </summary>
        public bool PassProtected { get; set; }

        /// <summary>
        /// The status of the game
        /// </summary>
        public GameStatus Status;

        /// <summary>
        /// The current number of votes to start the game
        /// </summary>
        public int StartVotes = 0;

        /// <summary>
        /// A list of all the players in the game
        /// </summary>
        public List<GamePlayer> Players = new List<GamePlayer>();
    }

    class GamePlayer
    {
        /// <summary>
        /// The username of the player
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Whether or not the player is currently in a game
        /// </summary>
        public bool InGame { get; set; }
    }

    /// <summary>
    /// An enumeration of the different status a game can be in
    /// </summary>
    enum GameStatus
    {
        InGame,
        Waiting
    }
}
