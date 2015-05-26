using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DotsNBoxesServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Let the user know the server is starting up
            Console.WriteLine("Initializing Server...");

            //Start the game server
            GameServer mainGameServer = new GameServer(new ServerSettings(3000, 50));
            mainGameServer.StartServer();
        }
    }
}
