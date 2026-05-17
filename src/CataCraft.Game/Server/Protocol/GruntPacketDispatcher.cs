// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;
using CataCraft.Game.Server.Protocol.Packets.GruntPackets;

namespace CataCraft.Game.Server.Protocol;

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
