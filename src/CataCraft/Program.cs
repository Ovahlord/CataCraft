using System.Net;
using System.Net.Sockets;
using CataCraft.Core.Configuration;
using CataCraft.Core.Cryptography;
using CataCraft.Database;
using CataCraft.DBC;
using CataCraft.Game.Realm;
using CataCraft.Game.Server.Networking;

namespace CataCraft;

public static class Program
{
    public static async Task Main(string[] args)
    {
        // Load appsettings.json
        AppSettings.LoadConfiguration();

        // Load DBC files
        DBCManager.LoadStorages();

        // Set up database if needed
        if (await DatabaseManager.InitializeDatabasesAsync())
        {
            Console.WriteLine("Databases have been successfully initialized");

            if (AppSettings.TryGetConfigValue("CreateDefaultAdminAccount", out bool create) && create)
            {
                (byte[] salt, byte[] verifier) = SRP6.GenerateRegistrationData("ADMIN", "admin");
                if (await DatabaseManager.CreateGameAccountAsync("ADMIN", "admin@admin", salt, verifier))
                    Console.WriteLine("Created admin GameAccount - user: admin || pass: admin");
            }

            if (AppSettings.TryGetConfigValue("CreateDefaultRealm", out create) && create)
            {
                if (await DatabaseManager.CreateDefaultRealmAsync())
                    Console.WriteLine("Default realm 'CataCraft' has been created");
            }

            await DatabaseManager.ImportGameData();
        }

        // Load realms
        await RealmManager.LoadRealmsAsync();

        // Start realms
        RealmManager.OpenAllRealms();

        // Start listening for new login connections
        if (AppSettings.TryGetConfigValue("LoginIpEndpoint", out string? ipEndpoint))
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
