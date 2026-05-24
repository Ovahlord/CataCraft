// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientTutorialFlag
{
    public uint TutorialBit { get; private set; }

    public ClientTutorialFlag(ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        TutorialBit = reader.ReadUInt32();

    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientTutorialFlag clientTutorialFlag = new(payload);

        byte tutorialIndex = (byte)(clientTutorialFlag.TutorialBit >> 5);
        if (tutorialIndex > 7)
        {
            session.Close();
            return;
        }

        uint tutorialFlag = 1u << (int)(clientTutorialFlag.TutorialBit & 0x1F);
        session.TutorialBits[tutorialIndex] |= tutorialFlag;
    }
}
