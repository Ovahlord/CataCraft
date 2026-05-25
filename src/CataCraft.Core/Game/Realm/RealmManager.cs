// This file is part of the CataCraft project, which is published under the MIT license.

using System.Collections.Concurrent;
using CataCraft.Database.Realm;

namespace CataCraft.Core.Game.Realm;

public static class RealmManager
{
    // Public properties
    public static List<Realm> Realms => s_realms.Values.ToList();

    // Internal fields
    private static readonly Dictionary<int, Realm> s_realms = [];

    public static async Task LoadRealmsAsync()
    {
        await using RealmDbContext realmDb = new();
        List<Database.Realm.Model.Realm> realmDbEntries = realmDb.Realms.ToList();

        foreach (Database.Realm.Model.Realm realmDbEntry in realmDbEntries)
        {
            Realm realm = new(realmDbEntry);
            realm.Open();
            s_realms.Add(realmDbEntry.Id, realm);
        }

        Console.WriteLine($"Realms loaded: {s_realms.Count} realms from database");
    }
}
