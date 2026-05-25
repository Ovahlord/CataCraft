// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Networking;
using CataCraft.Core.Utils;
using CataCraft.Database.Login;
using CataCraft.Database.Login.Model;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public struct ClientUpdateAccountData
{
    public AccountDataType DataType { get; private set; }
    public DateTimeOffset Time { get; private set; }
    public int Size { get; private set; }
    public byte[] Data { get; private set; }

    public ClientUpdateAccountData(ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new ClientPacketReader(payload);
        DataType = (AccountDataType)reader.ReadInt32();
        Time = DateTimeOffset.FromUnixTimeSeconds(reader.ReadUInt32());
        Size = reader.ReadInt32();

        if (Size == 0)
        {
            Data = [];
            return;
        }

        Data = new byte[Size];
        ZLib.InflateData(reader.ReadBytes((int)reader.UnreadBytes), Data);
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientUpdateAccountData updateAccountData = new(payload);
        if (!Enum.IsDefined(updateAccountData.DataType))
        {
            session.Close();
            return;
        }

        switch (updateAccountData.DataType)
        {
            // Per character data is indexed by character
            case AccountDataType.PerCharacterConfigCache:
            case AccountDataType.PerCharacterBindingsCache:
            case AccountDataType.PerCharacterMacrosCache:
            case AccountDataType.PerCharacterLayoutCache:
            case AccountDataType.PerCharacterChatCache:
                {
                    if (session.Player == null)
                        return;

                    await using RealmDbContext realmDb = new();
                    CharacterData? characterData = await realmDb.CharacterDataEntries
                        .FirstOrDefaultAsync(cd => cd.CharacterId == session.Player.Guid.Counter &&
                                                   cd.Id == (int)updateAccountData.DataType);

                    if (characterData == null)
                    {
                        realmDb.CharacterDataEntries.Add(new CharacterData()
                        {
                            CharacterId = (int)session.Player.Guid.Counter,
                            Id = (int)updateAccountData.DataType,
                            Data = updateAccountData.Data,
                            Time = updateAccountData.Time
                        });
                    }
                    else
                    {
                        characterData.Data = updateAccountData.Data ?? [];
                        characterData.Time = updateAccountData.Time;
                    }

                    await realmDb.SaveChangesAsync();
                    break;
                }
            default:
                {
                    // Global account data is account wide
                    await using LoginDbContext loginDb = new();
                    GameAccountData? accountData = await loginDb.GameAccountDataEntries
                        .FirstOrDefaultAsync(ga => ga.GameAccountId == session.GameAccountId && ga.Id == (int)updateAccountData.DataType);

                    if (accountData == null)
                    {
                        loginDb.GameAccountDataEntries.Add(new GameAccountData()
                        {
                            GameAccountId = session.GameAccountId,
                            Id = (int)updateAccountData.DataType,
                            Data = updateAccountData.Data,
                            Time = updateAccountData.Time
                        });
                    }
                    else
                    {
                        accountData.Data = updateAccountData.Data ?? [];
                        accountData.Time = updateAccountData.Time;
                    }

                    await loginDb.SaveChangesAsync();
                    break;
                }
        }


        ServerUpdateAccountDataComplete updateAccountDataComplete = new()
        {
            DataType = updateAccountData.DataType,
            Result = 0
        };

        session.EnqueuePacket(ref updateAccountDataComplete);
    }
}
