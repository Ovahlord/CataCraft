// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GruntPackets;

public ref struct ServerAuthLogonChallenge : IServerPacket
{
    private static readonly byte[] s_versionChallenge = [0xBA, 0xA3, 0x1E, 0x99, 0xA0, 0x0B, 0x21, 0x57, 0xFC, 0x37, 0x3F, 0xB3, 0x69, 0xCD, 0xD2, 0xF1];

    public struct PinData
    {
        public uint PinGridSeed { get; set; }
        public byte[] PinSalt { get; set; }
    }

    public struct MatrixCardData
    {
        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte DigitCount { get; set; }
        public byte ChallengeCount { get; set; }
        public ulong Seed { get; set; }
    }

    public struct AuthenticatorData
    {
        public bool Required { get; set; }
    }

    public int Opcode => (int)GruntOpcodes.AuthLogonChallenge;

    public byte ProtocolVersion { get; set; }
    public AuthResult Error { get; set; }
    public byte[] B { get; set; } = [];
    public byte[] S { get; set; } = [];
    public byte[] VersionChallenge { get; set; } = s_versionChallenge;
    public byte[] G { get; set; } = [];
    public byte[] N { get; set; } = [];
    public SecurityFlags SecurityFlag { get; set; }

    public PinData Pin { get; set; }
    public MatrixCardData MatrixCard { get; set; }
    public AuthenticatorData Authenticator { get; set; }

    public ServerAuthLogonChallenge()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteUInt8(ProtocolVersion);
        writer.WriteUInt8((byte)Error);

        if (Error == AuthResult.WowSuccess)
        {
            writer.WriteBytes(B);
            writer.WriteUInt8((byte)G.Length);
            writer.WriteBytes(G);
            writer.WriteUInt8((byte)N.Length);
            writer.WriteBytes(N);
            writer.WriteBytes(S);
            writer.WriteBytes(VersionChallenge);
            writer.WriteUInt8((byte)SecurityFlag);

            if (SecurityFlag.HasFlag(SecurityFlags.Pin))
            {
                writer.WriteUInt32(Pin.PinGridSeed);
                writer.WriteBytes(Pin.PinSalt);
            }

            if (SecurityFlag.HasFlag(SecurityFlags.MatrixCard))
            {
                writer.WriteUInt8(MatrixCard.Width);
                writer.WriteUInt8(MatrixCard.Height);
                writer.WriteUInt8(MatrixCard.DigitCount);
                writer.WriteUInt8(MatrixCard.ChallengeCount);
                writer.WriteUInt64(MatrixCard.Seed);
            }

            if (SecurityFlag.HasFlag(SecurityFlags.Authenticator))
                writer.WriteBool(Authenticator.Required);
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
