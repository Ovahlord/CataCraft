// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Server.Protocol.Packets;
using CataCraft.Game.Entities.Object;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ServerInventoryChangeFailure : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_INVENTORY_CHANGE_FAILURE;

    public BagResult BagResult { get; set; }
    public byte ContainerBSlot { get; set; }
    public int Level { get; set; }
    public int SrcSlot { get; set; }
    public int LimitCategory { get; set; }
    public WowGuid[] Item { get; set; } = new WowGuid[2];
    public WowGuid SrcContainer { get; set; }
    public WowGuid DstContainer { get; set; }

    public ServerInventoryChangeFailure()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteInt8((sbyte)BagResult);
        if (BagResult != BagResult.Ok)
        {
            foreach (WowGuid itemGuid in Item)
            {
                writer.WriteUInt64(itemGuid);
            }

            writer.WriteUInt8(ContainerBSlot);

            switch (BagResult)
            {
                case BagResult.CantEquipLevel:
                case BagResult.PurchaseLevelTooLow:
                    writer.WriteInt32(Level);
                    break;
                case BagResult.EventAutoEquipBindConfirm:
                    writer.WriteUInt64(SrcContainer);
                    writer.WriteInt32(SrcSlot);
                    writer.WriteUInt64(DstContainer);
                    break;
                case BagResult.ItemMaxLimitCategoryCountExceeded:
                case BagResult.ItemMaxLimitCategorySocketedExceeded:
                case BagResult.ItemMaxLimitCategoryEquippedExceeded:
                    writer.WriteInt32(LimitCategory);
                    break;
                default:
                    break;
            }
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
