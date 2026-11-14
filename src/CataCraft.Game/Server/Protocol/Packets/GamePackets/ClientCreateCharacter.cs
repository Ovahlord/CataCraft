// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Database.Game;
using CataCraft.Database.Game.Entities;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Entities;
using CataCraft.DBC;
using CataCraft.DBC.Model;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public struct ClientCreateCharacter
{
    public string Name { get; private set; } = string.Empty;
    public byte RaceID { get; private set; }
    public byte ClassID { get; private set; }
    public byte SexID { get; private set; }
    public byte SkinID { get; private set; }
    public byte FaceID { get; private set; }
    public byte HairStyleID { get; private set; }
    public byte HairColorID { get; private set; }
    public byte FacialHairStyleID { get; private set; }
    public byte OutfitID { get; private set; }

    private const int MaxCharactersPerRealm   = 10;
    private const int MaxCharactersPerAccount = 50;

    private ClientCreateCharacter(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        Name = reader.ReadCString();
        RaceID = reader.ReadUInt8();
        ClassID = reader.ReadUInt8();
        SexID = reader.ReadUInt8();
        SkinID = reader.ReadUInt8();
        FaceID = reader.ReadUInt8();
        HairStyleID = reader.ReadUInt8();
        HairColorID = reader.ReadUInt8();
        FacialHairStyleID = reader.ReadUInt8();
        OutfitID = reader.ReadUInt8();
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientCreateCharacter createCharacter = new(payload);

        // Check for a valid race and class selection
        if (!DBCManager.SChrRacesStore.ContainsKey(createCharacter.RaceID) ||
            !DBCManager.SChrClassesStore.ContainsKey(createCharacter.ClassID))
        {
            SendCharCreateResponse(ResponseCodes.CharCreateError, session);
            return;
        }

        // Determine the starting location
        CharacterStartPosition? startPosition = GameDbCache.CharacterStartPositions
            .FirstOrDefault(p => p.ClassId == createCharacter.ClassID && p.RaceId == createCharacter.RaceID);

        if (startPosition == null)
        {
            SendCharCreateResponse(ResponseCodes.CharCreateError, session);
            return;
        }

        await using RealmDbContext realmDb = new();
        List<Character> realmCharacters = await realmDb.Characters
            .Where(rc => rc.RealmId == session.Realm.RealmId && rc.GameAccountId == session.GameAccountId)
            .ToListAsync();

        // Disable character creation in locked realms for accounts who don't have an account yet
        if (realmCharacters.Count == 0 && session.Realm.LockedForNewPlayers)
        {
            SendCharCreateResponse(ResponseCodes.CharCreateOnlyExisting, session);
            return;
        }

        // Enforce the character limit
        if (realmCharacters.Count >= MaxCharactersPerRealm)
        {
            SendCharCreateResponse(ResponseCodes.CharCreateServerLimit, session);
            return;
        }

        // Normalize the account name
        createCharacter.Name = char.ToUpperInvariant(createCharacter.Name[0]) + createCharacter.Name.Substring(1);

        if (await realmDb.Characters.AnyAsync(c => c.Name.Equals(createCharacter.Name)))
        {
            SendCharCreateResponse(ResponseCodes.CharCreateNameInUse, session);
            return;
        }

        // Calculate the list position
        byte listPosition = 1;
        if (realmCharacters.Count > 0)
        {
            listPosition = realmCharacters.Max(rc => rc.ListPositionIndex);
            listPosition += 1;
        }

        // Prepare the database entries
        CharacterStats characterStats = new()
        {
            MapId = startPosition.MapId,
            PositionX = startPosition.PositionX,
            PositionY = startPosition.PositionY,
            PositionZ = startPosition.PositionZ,
            Facing = startPosition.Facing
        };

        Character character = new()
        {
            RealmId =  session.Realm.RealmId,
            GameAccountId = session.GameAccountId,
            ListPositionIndex = listPosition,
            Name = createCharacter.Name,
            RaceId = createCharacter.RaceID,
            ClassId = createCharacter.ClassID,
            SexId = createCharacter.SexID,
            HairStyleId = createCharacter.HairStyleID,
            HairColorId = createCharacter.HairColorID,
            FacialHairStyleId = createCharacter.FacialHairStyleID,
            FaceId = createCharacter.FaceID,
            Stats = characterStats,
        };

        // Create the starting outfit
        CharStartOutfitEntry? startOutfitEntry = DBCManager.SCharStartOutfitStore.Values
            .FirstOrDefault(o => o.ClassID == createCharacter.ClassID &&
                                 o.RaceID == createCharacter.RaceID &&
                                 o.SexID == createCharacter.SexID);

        if (startOutfitEntry != null)
            CreateStartingInventory(character, startOutfitEntry);

        realmDb.Characters.Add(character);

        try
        {
            int affectedRows = await realmDb.SaveChangesAsync();
            if (affectedRows == 0)
                SendCharCreateResponse(ResponseCodes.CharCreateFailed, session);
            else
                SendCharCreateResponse(ResponseCodes.CharCreateSuccess, session);
        }
        catch (Exception)
        {
            SendCharCreateResponse(ResponseCodes.CharCreateFailed, session);
        }
    }

    private static void SendCharCreateResponse(ResponseCodes response, GameSession session)
    {
        ServerCreateChar createChar = new(response);
        session.EnqueuePacket(ref createChar);
    }

    private static void CreateStartingInventory(Character characterDbEntry, CharStartOutfitEntry startOutfitEntry)
    {
        int currentBackpackSlot = (int)InventorySlot.ItemStart;
        int currentRingSlot = (int)InventorySlot.Finger1;
        int currentBagSlot = (int)InventorySlot.Bag1;
        int currentWeaponSlot = (int)InventorySlot.Mainhand;
        int currentTrinketSlot = (int)InventorySlot.Trinket1;

        for (int i = 0; i < startOutfitEntry.ItemID.Length; ++i)
        {
            if (startOutfitEntry.ItemID[i] <= 0 || !DBCManager.SItemStore.TryGetValue(startOutfitEntry.ItemID[i], out ItemEntry? itemEntry))
                continue;

            int itemSlot = -1;

            switch ((InventoryType)itemEntry.InventoryType)
            {
                case InventoryType.NonEquip:
                    itemSlot = currentBackpackSlot++;
                    break;
                case InventoryType.Chest:
                case InventoryType.Robe:
                    itemSlot = (int)InventorySlot.Chest;
                    break;
                case InventoryType.Body:
                    itemSlot = (int)InventorySlot.Body;
                    break;
                case InventoryType.Feet:
                    itemSlot = (int)InventorySlot.Feet;
                    break;
                case InventoryType.Legs:
                    itemSlot = (int)InventorySlot.Legs;
                    break;
                case InventoryType.Hands:
                    itemSlot = (int)InventorySlot.Hands;
                    break;
                case InventoryType.Shoulders:
                    itemSlot = (int)InventorySlot.Shoulders;
                    break;
                case InventoryType.Bag:
                    itemSlot = currentBagSlot++;
                    break;
                case InventoryType.Wrists:
                    itemSlot = (int)InventorySlot.Wrists;
                    break;
                case InventoryType.Head:
                    itemSlot = (int)InventorySlot.Head;
                    break;
                case InventoryType.Waist:
                    itemSlot = (int)InventorySlot.Waist;
                    break;
                case InventoryType.Neck:
                    itemSlot = (int)InventorySlot.Neck;
                    break;
                case InventoryType.Cloak:
                    itemSlot = (int)InventorySlot.Back;
                    break;
                case InventoryType.Weapon:
                    itemSlot = currentWeaponSlot++;
                    break;
                case InventoryType.Trinket:
                    itemSlot = currentTrinketSlot++;
                    break;
                case InventoryType.Tabard:
                    itemSlot = (int)InventorySlot.Tabard;
                    break;
                case InventoryType.WeaponMainhand:
                case InventoryType.TwoHandedWeapon:
                    itemSlot = (int)InventorySlot.Mainhand;
                    break;
                case InventoryType.WeaponOffhand:
                case InventoryType.Holdable:
                case InventoryType.Shield:
                    itemSlot = (int)InventorySlot.Offhand;
                    break;
                case InventoryType.Finger:
                    itemSlot = currentRingSlot++;
                    break;
                case InventoryType.Ranged:
                case InventoryType.Thrown:
                case InventoryType.RangedRight:
                    itemSlot = (int)InventorySlot.Ranged;
                    break;
                case InventoryType.Relic:
                    itemSlot = (int)InventorySlot.Ranged;
                    break;
                default:
                    break;
            }

            if (itemSlot != -1)
            {
                ItemInstance item = new()
                {
                    Id = 0,
                    ItemId = (int)itemEntry.ID,
                    ItemDisplayId = itemEntry.DisplayInfoID
                };

                CharacterInventory inventoryItem = new()
                {
                    InventorySlot = itemSlot,
                    Character =  characterDbEntry,
                    Item = item
                };

                characterDbEntry.Inventory.Add(inventoryItem);
            }
        }
    }
}
