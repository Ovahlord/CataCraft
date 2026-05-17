// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Game.World.Entities.Object;
using CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerQueryPlayerNameResponse : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_QUERY_PLAYER_NAME_RESPONSE;

    public WowGuid Player { get; set; } = null!;
    public byte Result { get; set; }
    public PlayerGuidLookupData Data { get; set; }

    public ServerQueryPlayerNameResponse()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WritePackGUID(Player);
        writer.WriteUInt8(Result);

        if (Result == 0)
        {

            writer.WriteCString(Data.Name);
            writer.WriteCString(Data.RealmName);
            writer.WriteUInt8(Data.Race);
            writer.WriteUInt8(Data.Sex);
            writer.WriteUInt8(Data.ClassID);

            writer.WriteBool(false); // Has declinedname
            //if (lookupData.DeclinedNames.has_value())
            //    for (uint8 i = 0; i < MAX_DECLINED_NAME_CASES; ++i)
            //        data << lookupData.DeclinedNames->name[i];
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
