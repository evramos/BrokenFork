using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsNBoxesServer
{
    class ServerSettings
    {
        /// <summary>
        /// The port number to listen for new clients on
        /// </summary>
        public readonly int Port;

        /// <summary>
        /// The maximum number of clients allowed to connect to the sever at once
        /// </summary>
        public readonly int MaxClients;

        /// <summary>
        /// The size of packet buffer to use when reading from clients
        /// </summary>
        public readonly int PacketBufferSize = 1460;

        /// <summary>
        /// The version number of the server
        /// </summary>
        public readonly Version VersionNumber = new Version(1, 0);

        /// <summary>
        /// Initiates server settings for a settings XML file
        /// </summary>
        /// <param name="settingsPath">The path to the XML file to read the settings from</param>
        public ServerSettings(string settingsPath)
        {
            throw new NotImplementedException("Loading server settings from XML is not currently implemented");
        }

        /// <summary>
        /// Initiates server settings
        /// </summary>
        /// <param name="port">The port number to listen for new clients on</param>
        /// <param name="maxclients">The maximum number of clients that can connect to the server at a time</param>
        public ServerSettings(int port, int maxclients)
        {
            Port = port;
            MaxClients = maxclients;
        }
    }
}
