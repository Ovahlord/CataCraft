// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Server.Protocol.Packets;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ServerTutorialFlags : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_TUTORIAL_FLAGS;

    public uint[] TutorialData { set; get; } = new uint[8];

    public ServerTutorialFlags()
    {
    }

    public ServerTutorialFlags(uint[] tutorialData)
    {
        if (tutorialData.Length != 8)
            throw new InvalidDataException("tutorialData must contain 8 uint elements.");

        TutorialData = tutorialData;
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        foreach (uint tutorialData in TutorialData)
        {
            writer.WriteUInt32(tutorialData);

            buffer = writer.Buffer;
            payloadLength = writer.WrittenBytes;
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
