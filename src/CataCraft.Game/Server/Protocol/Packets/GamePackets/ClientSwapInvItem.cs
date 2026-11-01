// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ClientSwapInvItem
{
    public byte Slot1 { get; set; }
    public byte Slot2 { get; set; }

    public ClientSwapInvItem(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        Slot2 = reader.ReadUInt8();
        Slot1 = reader.ReadUInt8();
    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientSwapInvItem swapItem = new(payload);

        if (session.Player == null)
            return ValueTask.CompletedTask;

        session.Player.Inventory.SwapItem(InventorySlot.BackPack, swapItem.Slot1, InventorySlot.BackPack, swapItem.Slot2);

        return ValueTask.CompletedTask;
    }
}
