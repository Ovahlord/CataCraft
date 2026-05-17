// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Networking;
using CataCraft.Database.Login;
using CataCraft.Database.Login.Model;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientRequestAccountData
{
    public AccountDataType DataType { get; private set; }

    public ClientRequestAccountData(ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        DataType = (AccountDataType)reader.ReadUInt32();
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientRequestAccountData requestAccountData = new(payload);
        if (!Enum.IsDefined(requestAccountData.DataType))
        {
            session.Close();
            return;
        }

        await using LoginDbContext loginDb = new();
        GameAccountData? data = loginDb.GameAccountDataEntries.FirstOrDefault(gad => gad.GameAccountId == session.GameAccountId);
        if (data == null)
        {
            ServerUpdateAccountData serverUpdateAccountData = new()
            {
                DataType =  requestAccountData.DataType,
                Time = DateTimeOffset.UnixEpoch,
                Data = []
            };

            session.EnqueuePacket(ref serverUpdateAccountData);
        }
        else
        {
            ServerUpdateAccountData serverUpdateAccountData = new()
            {
                DataType =  requestAccountData.DataType,
                Time = data.Time,
                Data = data.Data
            };

            session.EnqueuePacket(ref serverUpdateAccountData);
        }
    }
}
