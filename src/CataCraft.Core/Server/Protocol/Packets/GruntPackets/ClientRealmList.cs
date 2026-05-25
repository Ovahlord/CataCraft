// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Enums;
using CataCraft.Core.Game.Realm;
using CataCraft.Core.Server.Networking;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;

namespace CataCraft.Core.Server.Protocol.Packets.GruntPackets;

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
        List<RealmCharacter> realmCharacters = realmDb.RealmCharacters
            .Where(rc => rc.GameAccountId == session.GameAccountId)
            .ToList();

        ServerRealmList realmList = new();
        foreach (Game.Realm.Realm realm in RealmManager.Realms)
        {
            SubStructures.Realm realmEntry = new()
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

            realmList.Realms.Add(realmEntry);
        }

        session.EnqueuePacket(ref realmList);

        // Reset state back to authenticated to allow new realm list requests
        session.GruntAuthenticationState = GruntAuthenticationState.Authenticated;
    }
}
