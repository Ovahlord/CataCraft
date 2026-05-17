// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers.Binary;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Protocol.Packets.GruntPackets.SubStructures;

namespace CataCraft.Core.Server.Protocol.Packets.GruntPackets;

public struct ServerRealmList : IServerPacket
{
    public int Opcode => (int)GruntOpcodes.RealmList;

    public List<Realm> Realms { get; set; } = [];

    public ServerRealmList()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        Span<byte> packetSize = writer.GetSpan(sizeof(ushort));
        writer.WriteUInt32(0); // padding
        writer.WriteUInt16((byte)Realms.Count);

        foreach (Realm realm in Realms)
        {
            writer.WriteUInt8((byte)realm.Type);
            writer.WriteBool(realm.Locked);
            writer.WriteUInt8((byte)realm.Flags);
            writer.WriteCString(realm.Name);
            writer.WriteCString(realm.Address);
            writer.WriteFloat(realm.Population);
            writer.WriteUInt8(realm.NumCharacters);
            writer.WriteUInt8(realm.RealmCategory);
            writer.WriteUInt8(realm.RealmId);

            if (realm.Flags.HasFlag(RealmFlags.SpecifyBuild))
            {
                // @todo
                writer.WriteUInt8(0);
                writer.WriteUInt8(0);
                writer.WriteUInt8(0);
                writer.WriteUInt16(0);
            }
        }

        writer.WriteUInt16(0);

        BinaryPrimitives.WriteUInt16LittleEndian(packetSize, (ushort)(writer.WrittenBytes - packetSize.Length));

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
