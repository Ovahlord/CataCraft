// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ClientSwapItem
{
    // Source
    public byte SlotA { get; set; }
    public byte ContainerSlotA { get; set; }

    // Target
    public byte SlotB { get; set; }
    public byte ContainerSlotB { get; set; }

    public ClientSwapItem(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);

        ContainerSlotB = reader.ReadUInt8();
        SlotB = reader.ReadUInt8();

        ContainerSlotA = reader.ReadUInt8();
        SlotA = reader.ReadUInt8();

    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientSwapItem swapItem = new(payload);

        if (session.Player == null)
            return ValueTask.CompletedTask;

        session.Player.Inventory.SwapItem((InventorySlot)swapItem.ContainerSlotA, swapItem.SlotA, (InventorySlot)swapItem.ContainerSlotB, swapItem.SlotB);

        return ValueTask.CompletedTask;
    }
}
