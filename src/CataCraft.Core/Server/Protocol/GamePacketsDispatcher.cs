// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Networking;
using CataCraft.Core.Server.Protocol.Packets.GamePackets;

namespace CataCraft.Core.Server.Protocol;

using PacketHandler = Func<ReadOnlySequence<byte>, GameSession, ValueTask>;

public static class GamePacketsDispatcher
{
    private static readonly FrozenDictionary<GameClientOpcodes, PacketHandler> s_packetHandlers =
        new Dictionary<GameClientOpcodes, PacketHandler>()
        {
            { GameClientOpcodes.CMSG_AUTH_SESSION, ClientAuthSession.HandlePacket },
            { GameClientOpcodes.CMSG_ENUM_CHARACTERS, ClientEnumCharacters.HandlePacket },
            { GameClientOpcodes.CMSG_LOG_DISCONNECT, ClientLogDisconnect.HandlePacket },
            { GameClientOpcodes.CMSG_CREATE_CHARACTER, ClientCreateCharacter.HandlePacket },
            { GameClientOpcodes.CMSG_PLAYER_LOGIN, ClientPlayerLogin.HandlePacket },
            { GameClientOpcodes.CMSG_CHAR_DELETE, ClientCharDelete.HandlePacket },
            { GameClientOpcodes.CMSG_SET_ACTIVE_MOVER, ClientSetActiveMover.HandlePacket },
            { GameClientOpcodes.CMSG_QUERY_PLAYER_NAME, ClientQueryPlayerName.HandlePacket },
            { GameClientOpcodes.CMSG_READY_FOR_ACCOUNT_DATA_TIMES, ClientReadyForAccountDataTimes.HandlePacket },
            { GameClientOpcodes.CMSG_PING, ClientPing.HandlePacket },
            { GameClientOpcodes.CMSG_UPDATE_ACCOUNT_DATA, ClientUpdateAccountData.HandlePacket },
            { GameClientOpcodes.CMSG_REQUEST_ACCOUNT_DATA, ClientRequestAccountData.HandlePacket }
        }.ToFrozenDictionary();

    public static bool TryGetPacketHandler(GameClientOpcodes opcode, [NotNullWhen(true)] out PacketHandler? handler)
    {
        return s_packetHandlers.TryGetValue(opcode, out handler);
    }
}
