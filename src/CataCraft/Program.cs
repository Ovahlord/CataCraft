using System.Net;
using System.Net.Sockets;
using CataCraft.Configuration;
using CataCraft.Core.Cryptography;
using CataCraft.Core.Game.Realm;
using CataCraft.Core.Server.Networking;
using CataCraft.Database;
using CataCraft.DBC;

namespace CataCraft;

class Program
{
    static async Task Main(string[] args)
    {
        // Load Config.json
        ConfigManager.LoadConfiguration();

        // Load DBC files
        DBCManager.LoadStoragesAsync();

        // Set up database if needed
        if (await DatabaseManager.InitializeDatabasesAsync())
        {
            Console.WriteLine("Databases have been successfully initialized");

            if (ConfigManager.TryGetConfigValue("CreateDefaultAdminAccount", out bool create) && create)
            {
                (byte[] salt, byte[] verifier) = SRP6.GenerateRegistrationData("ADMIN", "admin");
                if (await DatabaseManager.CreateGameAccountAsync("ADMIN", "admin@admin", salt, verifier))
                    Console.WriteLine("Created admin GameAccount - user: admin || pass: admin");
            }

            if (ConfigManager.TryGetConfigValue("CreateDefaultRealm", out create) && create)
            {
                await DatabaseManager.CreateDefaultRealmAsync();
                Console.WriteLine("Default realm 'CataCraft' has been created");
            }
        }

        // Load realms from database
        await RealmManager.LoadRealmsAsync();

        // Start Grunt connection listener
        if (ConfigManager.TryGetConfigValue("LoginIpEndpoint", out string? ipEndpoint))
        {
            TcpListener listener = new(IPEndPoint.Parse(ipEndpoint));
            listener.Start();

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                Console.WriteLine($"Client connected: {client.Client.RemoteEndPoint}");
                GruntSession session = new(client);
            }
        }
    }
}
