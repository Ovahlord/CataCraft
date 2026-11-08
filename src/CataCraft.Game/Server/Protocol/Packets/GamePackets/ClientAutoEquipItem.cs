// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ClientAutoEquipItem
{
    public byte Slot { get; set; }
    public byte PackSlot { get; set; }

    public ClientAutoEquipItem(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);

        Slot = reader.ReadUInt8();
        PackSlot = reader.ReadUInt8();
    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientAutoEquipItem autoEquipItem = new(payload);

        if (session.Player == null)
            return ValueTask.CompletedTask;

        session.Player.Inventory.AutoEquipItem((InventorySlot)autoEquipItem.Slot, autoEquipItem.PackSlot);

        return ValueTask.CompletedTask;
    }
}
