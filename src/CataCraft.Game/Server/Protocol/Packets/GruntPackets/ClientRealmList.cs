// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Database.Realm;
using CataCraft.Game.Enums;
using CataCraft.Game.Realm;
using CataCraft.Game.Server.Networking;
using CataCraft.Game.Server.Protocol.Packets.GruntPackets.SubStructures;

namespace CataCraft.Game.Server.Protocol.Packets.GruntPackets;

public ref struct ClientRealmList
{
    private ClientRealmList(in ReadOnlySequence<byte> _)
    {
        // No payload is being parsed
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> _, GruntSession session)
    {
        if (session.GruntAuthenticationState != GruntAuthenticationState.Authenticated)
        {
            session.Close();
            return;
        }

        session.GruntAuthenticationState = GruntAuthenticationState.RequestingRealmList;

        await using RealmDbContext realmDb = new();
        var realmCharacters = realmDb.Characters
            .Select(c => new { c.GameAccountId, c.RealmId })
            .Where(c => c.GameAccountId == session.GameAccountId);

        ServerRealmList realmList = new();
        foreach (var realm in RealmManager.Realms.Values)
        {
            RealmListRealm realmEntry = new()
            {
                Type = realm.Type,
                Locked = realm.LockedForNewPlayers,
                Name =  realm.RealmName,
                Address = realm.EntryIpEndpoint.ToString(),
                Population = realm.Population,
                RealmCategory = realm.RealmCategory,
                RealmId = realm.RealmId,
                NumCharacters = (byte)realmCharacters.Count(rc => rc.RealmId == realm.RealmId)
            };

            if (realm.RecommendedForNewPlayers)
                realmEntry.Flags |= RealmFlags.NewPlayers;

            if (!realm.Online)
                realmEntry.Flags |= RealmFlags.Offline;

            if (realm.IsFull)
                realmEntry.Flags |= RealmFlags.Full;

            realmList.Realms.Add(realmEntry);
        }

        session.EnqueuePacket(ref realmList);

        // Reset state back to authenticated to allow new realm list requests
        session.GruntAuthenticationState = GruntAuthenticationState.Authenticated;
    }

}
