using System.Net;
using System.Net.Sockets;
using CataCraft.Core.Cryptography;
using CataCraft.Core.Game.Realm;
using CataCraft.Core.Server.Networking;
using CataCraft.Database.Login;
using CataCraft.Database.Login.Model;
using CataCraft.Database.Realm;
using Realm = CataCraft.Database.Realm.Model.Realm;

namespace CataCraft;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting application...");

        Console.WriteLine("Ensuring Databases are created...");

        // =============== LOGIN DATABASE ========================
        await using LoginDbContext loginDb = new();
        if (await loginDb.Database.EnsureCreatedAsync())
        {
            (byte[] salt, byte[] verifier) = SRP6.GenerateRegistrationData("admin", "admin");

            GameAccount adminAccount = new()
            {
                AccountName = "ADMIN",
                Email = "admin@admin",
                Salt = salt,
                Verifier = verifier
            };

            loginDb.GameAccounts.Add(adminAccount);
            await loginDb.SaveChangesAsync();
            Console.WriteLine("Created login database with admin account (Account Name: admin, password: admin)");
        }


        // =============== REALM DATABASE ========================
        await using RealmDbContext realmDb = new();
        if (await realmDb.Database.EnsureCreatedAsync())
        {
            Realm realm = new()
            {
                RealmName = "CataCraft",
            };

            realmDb.Realms.Add(realm);
            await realmDb.SaveChangesAsync();
            Console.WriteLine("Created realm database with default realm 'CataCraft'");
        }

        await RealmManager.LoadRealms();

        TcpListener listener = new(IPEndPoint.Parse("127.0.0.1:3724"));
        listener.Start();

        while (true)
        {
            TcpClient client = await listener.AcceptTcpClientAsync();
            Console.WriteLine($"Client connected: {client.Client.RemoteEndPoint}");
            GruntSession session = new(client);
        }
    }
}
