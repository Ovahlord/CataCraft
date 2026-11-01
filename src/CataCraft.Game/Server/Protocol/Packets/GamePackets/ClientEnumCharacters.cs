// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Entities;
using CataCraft.DBC;
using CataCraft.DBC.Model;
using CataCraft.Game.Entities.Object;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;
using CataCraft.Game.Server.Protocol.Packets.GamePackets.SubStructures;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ClientEnumCharacters
{
    private ClientEnumCharacters(in ReadOnlySequence<byte> _)
    {
        // No payload is being parsed
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        await using RealmDbContext realmDb = new();
        GameSession gameSession = session;
        List<Character> realmCharacters = await realmDb.Characters
            .Include(rc => rc.Stats)
            .Include(rc => rc.Inventory).ThenInclude(i => i.Item)
            .Where(rc => rc.RealmId == gameSession.Realm.RealmId && rc.GameAccountId == gameSession.GameAccountId)
            .OrderBy(rc => rc.ListPositionIndex)
            .AsNoTracking()
            .ToListAsync();

        ServerEnumCharactersResult enumCharactersResult = new()
        {
            Success = true
        };

        foreach (Character character in realmCharacters)
        {
            CharacterListEntry listEntry = new()
            {
                Guid = new WowGuid(WowGuidType.Player, (uint)character.Id),
                Name = character.Name,
                ClassID = character.ClassId,
                FaceID = character.FaceId,
                HairStyle = character.HairStyleId,
                HairColor = character.HairColorId,
                RaceID = character.RaceId,
                SexID = character.SexId,
                SkinID = character.SkinId,
                FacialHair = character.FacialHairStyleId,
                ExperienceLevel = character.Stats.ExperienceLevel,
                Flags = (CharacterFlags)(character.Stats.CharacterFlags),
                Flags2 = (CharacterFlags2)(character.Stats.CharacterFlags2),
                ListPosition = character.ListPositionIndex,
                ZoneID = character.Stats.AreaId,
                MapID = character.Stats.MapId,
                PreloadPos = [character.Stats.PositionX, character.Stats.PositionY, character.Stats.PositionZ],
                FirstLogin = character.Stats.FirstLogin
            };

            foreach (CharacterInventory inventory in character.Inventory.Where(i => i.InventorySlot <= (int)InventorySlot.Bag4))
            {
                if (DBCManager.SItemStore.TryGetValue(inventory.Item.ItemId, out ItemEntry? item))
                {
                    CharacterListItem listItem = new()
                    {
                        InvType = (byte)item.InventoryType,
                        DisplayID = (uint)inventory.Item.ItemDisplayId
                    };

                    listEntry.InventoryItems[inventory.InventorySlot] = listItem;
                }

            }

            enumCharactersResult.Characters.Add(listEntry);
        }

        session.EnqueuePacket(ref enumCharactersResult);
    }
}
