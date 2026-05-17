// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Database.Realm;

namespace CataCraft.Game.Game.Realm;

public static class RealmManager
{
    // Public properties
    public static Dictionary<int, Realm> Realms { get; } = [];

    public static async Task LoadRealmsAsync()
    {
        await using RealmDbContext realmDb = new();
        List<Database.Realm.Model.Realm> realmDbEntries = realmDb.Realms.ToList();

        foreach (Database.Realm.Model.Realm realmDbEntry in realmDbEntries)
        {
            Realm realm = new(realmDbEntry);
            Realms.Add(realmDbEntry.Id, realm);
        }

        Console.WriteLine($"Realms loaded: {Realms.Count} realms from database");
    }

    public static void OpenAllRealms()
    {
        foreach (Realm realm in Realms.Values)
        {
            realm.Open();
        }
    }
}
