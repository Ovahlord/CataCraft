// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Game.Realm;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientCreateCharacter
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

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientCreateCharacter createCharacter = new(payload);
        RealmCharacterRequestManager.RequestCharacterCreation(session,
            createCharacter.Name,
            createCharacter.RaceID,
            createCharacter.ClassID,
            createCharacter.SexID,
            createCharacter.SkinID,
            createCharacter.FaceID,
            createCharacter.HairStyleID,
            createCharacter.HairColorID,
            createCharacter.FacialHairStyleID,
            createCharacter.OutfitID);

        return ValueTask.CompletedTask;
    }
}
