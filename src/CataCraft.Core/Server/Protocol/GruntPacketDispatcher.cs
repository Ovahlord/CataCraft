// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Networking;
using CataCraft.Core.Server.Protocol.Packets.GruntPackets;
using CataCraft.Core.Server.Protocol.Packets.GruntPackets.SubStructures;

namespace CataCraft.Core.Server.Protocol;

using PacketHandler = Func<ReadOnlySequence<byte>, GruntSession, ValueTask>;

public static class GruntPacketDispatcher
{
    private static readonly FrozenDictionary<GruntOpcodes, PacketHandler> s_packetHandlers = new Dictionary<GruntOpcodes, PacketHandler>()
        {
            { GruntOpcodes.AuthLogonChallenge, ClientAuthLogonChallenge.HandlePacket },
            { GruntOpcodes.AuthLogonProof, ClientAuthLogonProof.HandlePacket },
            { GruntOpcodes.RealmList, ClientRealmList.HandlePacket }
        }.ToFrozenDictionary();

    public static bool TryGetPacketHandler(GruntOpcodes opcode, [NotNullWhen(true)] out PacketHandler? handler)
    {
        return s_packetHandlers.TryGetValue(opcode, out handler);
    }
}
