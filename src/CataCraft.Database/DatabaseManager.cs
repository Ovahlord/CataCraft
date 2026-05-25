// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Database.Login;
using CataCraft.Database.Login.Model;
using CataCraft.Database.Realm;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database;

public static class DatabaseManager
{
    public static async Task<bool> InitializeDatabasesAsync()
    {
        await using LoginDbContext loginDb = new();
        bool created = await loginDb.Database.EnsureCreatedAsync();

        await using RealmDbContext realmDb = new();
        created |= await realmDb.Database.EnsureCreatedAsync();

        return created;
    }

    public static async Task<bool> CreateGameAccountAsync(string accountName, string email, byte[] salt, byte[] verifier)
    {
        try
        {
            bool checkMail = !string.IsNullOrWhiteSpace(email);

            await using LoginDbContext loginDb = new();
            GameAccount? gameAccount = await loginDb.GameAccounts
                .FirstOrDefaultAsync(ga => ga.AccountName == accountName || (checkMail && ga.Email == email));

            if (gameAccount != null)
                return false;

            GameAccount adminAccount = new()
            {
                AccountName = "ADMIN",
                Email = "admin@admin",
                Salt = salt,
                Verifier = verifier
            };

            GameAccountTutorial tutorial = new()
            {
                GameAccount = adminAccount,
                TutorialBits = new uint[8]
            };

            loginDb.GameAccounts.Add(adminAccount);
            loginDb.GameAccountTutorials.Add(tutorial);

            await loginDb.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public static async Task CreateDefaultRealmAsync()
    {
        await using RealmDbContext realmDb = new();
        Realm.Model.Realm realm = new()
        {
            RealmName = "CataCraft",
        };

        realmDb.Realms.Add(realm);
        await realmDb.SaveChangesAsync();
    }
}
