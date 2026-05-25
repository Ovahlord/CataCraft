// This file is part of the CataCraft project, which is published under the MIT license.

using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerConnectTo : IServerPacket
{
    #region RSA Key Data
    private static readonly byte[] s_P =
    [
        0x7D, 0xBD, 0xB9, 0xE1, 0x2D, 0xAE, 0x42, 0x56, 0x6E, 0x2B, 0xE2, 0x89, 0xD9, 0xBB, 0x0C, 0x1F,
        0x67, 0x28, 0xC1, 0x4D, 0x91, 0x3C, 0xAD, 0x5F, 0xF0, 0x43, 0x86, 0x5C, 0x27, 0xDC, 0x58, 0xB3,
        0x0E, 0x75, 0x77, 0x78, 0x49, 0x35, 0xE7, 0xE7, 0xDF, 0xFD, 0x74, 0xAB, 0x4E, 0xFE, 0xD3, 0xAB,
        0x6B, 0x96, 0xF7, 0x89, 0xB2, 0x5A, 0x6A, 0x25, 0x03, 0x5A, 0x92, 0x1A, 0xF1, 0xFC, 0x05, 0x4E,
        0xCE, 0xDD, 0x37, 0xA4, 0x02, 0x53, 0x76, 0xCB, 0xC2, 0xD9, 0x63, 0xCB, 0x51, 0x94, 0xEC, 0x5C,
        0x39, 0xCC, 0xB2, 0x17, 0x0C, 0xA3, 0x43, 0x9A, 0xD0, 0x83, 0x27, 0x67, 0x52, 0x64, 0x37, 0x0E,
        0x38, 0xB7, 0x9B, 0xF4, 0x2D, 0xB8, 0x0F, 0x30, 0x72, 0xD3, 0x15, 0xF3, 0x2C, 0x39, 0x55, 0x72,
        0x2C, 0x55, 0x80, 0x63, 0xA0, 0xA1, 0x6F, 0x28, 0xF3, 0xF3, 0x5A, 0x6F, 0x68, 0x59, 0xB3, 0xF3
    ];

    private static readonly byte[] s_Q =
    [
        0x0B, 0x1A, 0x13, 0x07, 0x12, 0xEF, 0xDD, 0x97, 0x01, 0x9A, 0x21, 0x7D, 0xFA, 0xA3, 0xB7, 0xE2,
        0x39, 0x2E, 0x04, 0x92, 0x96, 0x45, 0x2A, 0xEB, 0x57, 0x03, 0xAC, 0xB1, 0x83, 0xCD, 0x25, 0x4F,
        0x2C, 0xA9, 0xA1, 0x54, 0x26, 0x54, 0xCF, 0xE6, 0x1B, 0x53, 0x51, 0x3A, 0xC1, 0x15, 0xF4, 0x17,
        0xBB, 0x17, 0x1F, 0x37, 0x66, 0x36, 0x1A, 0xD4, 0xB1, 0x5B, 0x49, 0xA8, 0xF1, 0x02, 0xB0, 0x42,
        0xA9, 0x66, 0xA0, 0xE2, 0x52, 0x2C, 0x8C, 0x89, 0xA2, 0xDD, 0xA6, 0xF1, 0xA3, 0xDF, 0xB6, 0x80,
        0x63, 0xB8, 0x10, 0xDA, 0xDE, 0x84, 0x56, 0xFA, 0xFB, 0x72, 0x65, 0x5E, 0xA3, 0x9C, 0x78, 0x65,
        0xD0, 0x73, 0x07, 0x34, 0x1D, 0xE1, 0x4D, 0x77, 0xE8, 0x00, 0x0F, 0x80, 0x1C, 0x5A, 0x21, 0x55,
        0x0A, 0x8C, 0xF4, 0x93, 0xF5, 0xF8, 0x40, 0xF2, 0x40, 0xEA, 0x52, 0x12, 0x40, 0xF0, 0xBF, 0xFA
    ];

    private static readonly byte[] s_DP =
    [
        0xE1, 0xA6, 0x22, 0xAB, 0xFF, 0x57, 0x83, 0x45, 0x3F, 0x93, 0x76, 0xC8, 0xFA, 0xD9, 0x17, 0xE1,
        0x49, 0x73, 0xC2, 0x13, 0x28, 0x0B, 0x1F, 0xE2, 0x9A, 0xF4, 0x7F, 0x7C, 0x37, 0x56, 0xA1, 0xDF,
        0x51, 0x97, 0x2F, 0x15, 0x10, 0x97, 0xCD, 0x2A, 0x40, 0x09, 0xFC, 0x0A, 0xC3, 0x3F, 0x88, 0x86,
        0xA9, 0x51, 0x13, 0xE1, 0x76, 0xCF, 0xA8, 0x37, 0x9A, 0x91, 0x3B, 0xD0, 0x70, 0xA1, 0xD7, 0x03,
        0x71, 0x59, 0x6C, 0xB3, 0x41, 0xB8, 0x32, 0x68, 0x56, 0xC8, 0xB8, 0xD1, 0xF9, 0x1D, 0x04, 0xC5,
        0x13, 0xB5, 0x8E, 0x57, 0x73, 0x02, 0x97, 0x7B, 0x33, 0x60, 0x68, 0xA9, 0xC2, 0x40, 0x96, 0x3C,
        0x57, 0x4E, 0x4F, 0xC0, 0xAB, 0x21, 0x5C, 0xBA, 0x7D, 0x65, 0xAA, 0x1B, 0xD6, 0x43, 0x06, 0xCE,
        0x3E, 0x0C, 0xB9, 0xB2, 0x82, 0xB0, 0xC9, 0x54, 0x59, 0x32, 0xC5, 0x88, 0x08, 0x9C, 0x9B, 0xBF
    ];

    private static readonly byte[] s_DQ =
    [
        0xE3, 0xB1, 0xED, 0x52, 0xEF, 0xE6, 0x88, 0x40, 0x50, 0x89, 0x4C, 0x99, 0xE5, 0xF7, 0xED, 0x03,
        0x1C, 0x54, 0x11, 0x24, 0x2F, 0x9D, 0xE8, 0xE6, 0x39, 0xFA, 0x19, 0xF4, 0x06, 0x55, 0x0B, 0x8B,
        0x95, 0xC8, 0xB1, 0xE2, 0x7C, 0x75, 0x3B, 0x2A, 0x40, 0xC3, 0xE7, 0xE0, 0x25, 0x18, 0xBF, 0xB5,
        0x03, 0x1B, 0x5A, 0x57, 0x92, 0x3C, 0x85, 0x7D, 0x7F, 0x43, 0x56, 0x1F, 0x1E, 0x80, 0xC3, 0xBA,
        0xF0, 0x53, 0xD7, 0x6A, 0xD0, 0xF2, 0xDD, 0x9C, 0xC6, 0x53, 0xE7, 0xB4, 0xD3, 0x9D, 0xAB, 0xBF,
        0xE0, 0x97, 0x50, 0x92, 0x23, 0xB9, 0xB7, 0xDC, 0xAA, 0xC4, 0x20, 0x93, 0x5A, 0xF5, 0xDE, 0x76,
        0x28, 0x93, 0x91, 0x44, 0x1E, 0x4C, 0x15, 0x2F, 0x7F, 0x45, 0x3C, 0x3B, 0x7D, 0x36, 0x3B, 0x24,
        0xC7, 0x8C, 0x65, 0x43, 0xAE, 0x65, 0x84, 0xBC, 0xF9, 0x76, 0x4E, 0x3C, 0x44, 0x05, 0xBC, 0xFA
    ];

    private static readonly byte[] s_InverseQ =
    [
        0x63, 0xC1, 0x14, 0x2B, 0x57, 0x0B, 0x8A, 0x3C, 0x27, 0xDB, 0x96, 0x82, 0x27, 0xEB, 0xF6, 0x45,
        0x6D, 0x07, 0x50, 0xE8, 0x4A, 0xD4, 0xB6, 0x7A, 0x3C, 0x8B, 0x4D, 0x65, 0xF0, 0x50, 0x70, 0x84,
        0x71, 0x2B, 0xC6, 0x6D, 0x28, 0x2D, 0x76, 0x38, 0x73, 0x93, 0xDB, 0x44, 0xD7, 0xC0, 0x7F, 0xD9,
        0x57, 0x18, 0x28, 0x57, 0xF1, 0x13, 0x38, 0xA4, 0x91, 0x67, 0x1E, 0x13, 0x73, 0x55, 0xFC, 0x7B,
        0xAF, 0x50, 0xFA, 0xFD, 0x16, 0x12, 0x6F, 0xA4, 0x95, 0x15, 0x9C, 0x07, 0x18, 0xA6, 0x46, 0xFD,
        0xB3, 0xCF, 0xA5, 0x0E, 0x05, 0x30, 0xEC, 0x2C, 0xCD, 0x62, 0xDD, 0x6F, 0xB1, 0xFE, 0x6C, 0x05,
        0x2F, 0x11, 0xA6, 0xA0, 0x98, 0xAC, 0x9B, 0x15, 0xF0, 0x04, 0xC4, 0x7B, 0x79, 0xAA, 0x51, 0x25,
        0x2A, 0x84, 0x73, 0xE6, 0x77, 0x47, 0xA3, 0xEB, 0xCF, 0x6D, 0xC8, 0x96, 0x3A, 0x1B, 0x02, 0x52
    ];

    private static readonly byte[] s_WherePacketHmac =
    [
        0x2C, 0x1F, 0x1D, 0x80, 0xC3, 0x8C, 0x23, 0x64, 0xDA, 0x90, 0xCA, 0x8E, 0x2C, 0xFC, 0x0C, 0xCE,
        0x09, 0xD3, 0x62, 0xF9, 0xF3, 0x8B, 0xBE, 0x9F, 0x19, 0xEF, 0x58, 0xA1, 0x1C, 0x34, 0x14, 0x41,
        0x3F, 0x23, 0xFD, 0xD3, 0xE8, 0x14, 0xEC, 0x2A, 0xFD, 0x4F, 0x95, 0xBA, 0x30, 0x7E, 0x56, 0x5D,
        0x83, 0x95, 0x81, 0x69, 0xB0, 0x5A, 0xB4, 0x9D, 0xA8, 0x55, 0xFF, 0xFC, 0xEE, 0x58, 0x0A, 0x2F
    ];

    #endregion

    private static readonly string s_haiku = "World torn asunder\nDarkness descends on the land\nDeathwing has returned\n\0\0";

    private static readonly byte[] s_piDigits =
    [
        0x31, 0x41, 0x59, 0x26, 0x53, 0x58, 0x97, 0x93, 0x23, 0x84,
        0x62, 0x64, 0x33, 0x83, 0x27, 0x95, 0x02, 0x88, 0x41, 0x97,
        0x16, 0x93, 0x99, 0x37, 0x51, 0x05, 0x82, 0x09, 0x74, 0x94,
        0x45, 0x92, 0x30, 0x78, 0x16, 0x40, 0x62, 0x86, 0x20, 0x89,
        0x98, 0x62, 0x80, 0x34, 0x82, 0x53, 0x42, 0x11, 0x70, 0x67,
        0x98, 0x21, 0x48, 0x08, 0x65, 0x13, 0x28, 0x23, 0x06, 0x64,
        0x70, 0x93, 0x84, 0x46, 0x09, 0x55, 0x05, 0x82, 0x23, 0x17,
        0x25, 0x35, 0x94, 0x08, 0x12, 0x84, 0x81, 0x11, 0x74, 0x50,
        0x28, 0x41, 0x02, 0x70, 0x19, 0x38, 0x52, 0x11, 0x05, 0x55,
        0x96, 0x44, 0x62, 0x29, 0x48, 0x95, 0x49, 0x30, 0x38, 0x19,
        0x64, 0x42, 0x88, 0x10, 0x97, 0x56, 0x65, 0x93, 0x34, 0x46,
        0x12, 0x84, 0x75, 0x64, 0x82, 0x33, 0x78, 0x67, 0x83, 0x16,
        0x52, 0x71, 0x20, 0x19, 0x09, 0x14, 0x56, 0x48, 0x56, 0x69,
        0x23, 0x46, 0x03, 0x48, 0x61, 0x04, 0x54, 0x32, 0x66, 0x48,
        0x21, 0x33
    ];

    public int Opcode => (int)GameServerOpcodes.SMSG_CONNECT_TO;

    public ulong Key { get; set; }
    public uint Serial { get; set; }
    public ConnectToPayload Payload { get; set; }
    public ConnectToConnectionType Con { get; set; }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        byte[] address = new byte[16];
        byte[] addressBytes = Payload.Where.Address.GetAddressBytes();
        Buffer.BlockCopy(addressBytes, 0, address, 0, addressBytes.Length);

        uint addressType = 3;
        if (Payload.Where.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            addressType = 1;
        else if (Payload.Where.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            addressType = 2;

        ushort port = (ushort)Payload.Where.Port;
        byte[] haiku = Encoding.ASCII.GetBytes(s_haiku);

        using HMACSHA1 hmac = new(s_WherePacketHmac);
        hmac.TransformBlock(address, 0, address.Length, null, 0);
        hmac.TransformBlock(BitConverter.GetBytes(addressType), 0, sizeof(int), null, 0);
        hmac.TransformBlock(BitConverter.GetBytes(port), 0, sizeof(ushort), null, 0);
        hmac.TransformBlock(haiku, 0, 73, null, 0);
        hmac.TransformBlock(s_piDigits, 0, s_piDigits.Length, null, 0);
        hmac.TransformFinalBlock([Payload.XorMagic], 0, 1);

        byte[]? hmacResult = hmac.Hash;
        if (hmacResult == null)
            throw new OperationCanceledException("ConnectTo hashing failed!");

        ServerPacketWriter payloadWriter = new();

        payloadWriter.WriteUInt8(s_piDigits[30]);
        payloadWriter.WriteUInt8(haiku[31]);
        payloadWriter.WriteUInt8(s_piDigits[21]);
        payloadWriter.WriteUInt8(s_piDigits[26]);
        payloadWriter.WriteUInt8(haiku[3]);
        payloadWriter.WriteUInt8(s_piDigits[78]);
        payloadWriter.WriteUInt8(haiku[16]);
        payloadWriter.WriteUInt8(haiku[55]);
        payloadWriter.WriteUInt8(haiku[54]);
        payloadWriter.WriteUInt8(s_piDigits[68]);
        payloadWriter.WriteUInt8(s_piDigits[59]);
        payloadWriter.WriteUInt8(s_piDigits[115]);
        payloadWriter.WriteUInt8(haiku[65]);
        payloadWriter.WriteUInt8(hmacResult[15]);
        payloadWriter.WriteUInt8(haiku[25]);
        payloadWriter.WriteUInt8(s_piDigits[32]);
        payloadWriter.WriteUInt8(s_piDigits[101]);
        payloadWriter.WriteUInt8(haiku[37]);
        payloadWriter.WriteUInt8(haiku[20]);
        payloadWriter.WriteUInt8(haiku[29]);
        payloadWriter.WriteUInt8(s_piDigits[88]);
        payloadWriter.WriteUInt8(haiku[9]);
        payloadWriter.WriteUInt8(haiku[63]);
        payloadWriter.WriteUInt8(s_piDigits[3]);
        payloadWriter.WriteUInt8(s_piDigits[22]);
        payloadWriter.WriteUInt8(haiku[14]);
        payloadWriter.WriteUInt8(s_piDigits[38]);
        payloadWriter.WriteUInt8(s_piDigits[46]);
        payloadWriter.WriteUInt8(address[1]);
        payloadWriter.WriteUInt8(s_piDigits[94]);
        payloadWriter.WriteUInt8(s_piDigits[96]);
        payloadWriter.WriteUInt8(s_piDigits[137]);
        payloadWriter.WriteUInt8(haiku[42]);
        payloadWriter.WriteUInt8(haiku[21]);
        payloadWriter.WriteUInt8(s_piDigits[13]);
        payloadWriter.WriteUInt8(hmacResult[14]);
        payloadWriter.WriteUInt8(s_piDigits[63]);
        payloadWriter.WriteUInt8(s_piDigits[16]);
        payloadWriter.WriteUInt8(haiku[5]);
        payloadWriter.WriteUInt8(s_piDigits[58]);
        payloadWriter.WriteUInt8(haiku[67]);
        payloadWriter.WriteUInt8(haiku[53]);
        payloadWriter.WriteUInt8(s_piDigits[79]);
        payloadWriter.WriteUInt8(address[14]);
        payloadWriter.WriteUInt8(address[9]);
        payloadWriter.WriteUInt8(s_piDigits[125]);
        payloadWriter.WriteUInt8(haiku[24]);
        payloadWriter.WriteUInt8(haiku[6]);
        payloadWriter.WriteUInt8(s_piDigits[140]);
        payloadWriter.WriteUInt8(haiku[8]);
        payloadWriter.WriteUInt8(s_piDigits[112]);
        payloadWriter.WriteUInt8(s_piDigits[133]);
        payloadWriter.WriteUInt8(s_piDigits[74]);
        payloadWriter.WriteUInt8(s_piDigits[135]);
        payloadWriter.WriteUInt8(s_piDigits[50]);
        payloadWriter.WriteUInt8(s_piDigits[14]);
        payloadWriter.WriteUInt8(s_piDigits[85]);
        payloadWriter.WriteUInt8(hmacResult[19]);
        payloadWriter.WriteUInt8(s_piDigits[52]);
        payloadWriter.WriteUInt8(hmacResult[17]);
        payloadWriter.WriteUInt8(s_piDigits[136]);
        payloadWriter.WriteUInt8(s_piDigits[71]);
        payloadWriter.WriteUInt8(address[6]);
        payloadWriter.WriteUInt8(s_piDigits[87]);
        payloadWriter.WriteUInt8(s_piDigits[28]);
        payloadWriter.WriteUInt8(s_piDigits[105]);
        payloadWriter.WriteUInt8(haiku[32]);
        payloadWriter.WriteUInt8(s_piDigits[75]);
        payloadWriter.WriteUInt8(haiku[46]);
        payloadWriter.WriteUInt8(s_piDigits[5]);
        payloadWriter.WriteUInt8(s_piDigits[104]);
        payloadWriter.WriteUInt8(haiku[17]);
        payloadWriter.WriteUInt8(s_piDigits[64]);
        payloadWriter.WriteUInt8(haiku[22]);
        payloadWriter.WriteUInt8(address[3]);
        payloadWriter.WriteUInt8((byte)(port & 0xFF));
        payloadWriter.WriteUInt8(haiku[23]);
        payloadWriter.WriteUInt8(s_piDigits[0]);
        payloadWriter.WriteUInt8(address[5]);
        payloadWriter.WriteUInt8(s_piDigits[110]);
        payloadWriter.WriteUInt8(s_piDigits[109]);
        payloadWriter.WriteUInt8(s_piDigits[93]);
        payloadWriter.WriteUInt8(haiku[10]);
        payloadWriter.WriteUInt8(Payload.XorMagic);
        payloadWriter.WriteUInt8(haiku[26]);
        payloadWriter.WriteUInt8(haiku[13]);
        payloadWriter.WriteUInt8(s_piDigits[90]);
        payloadWriter.WriteUInt8(s_piDigits[72]);
        payloadWriter.WriteUInt8(s_piDigits[6]);
        payloadWriter.WriteUInt8(s_piDigits[54]);
        payloadWriter.WriteUInt8(address[0]);
        payloadWriter.WriteUInt8(s_piDigits[23]);
        payloadWriter.WriteUInt8(s_piDigits[100]);
        payloadWriter.WriteUInt8(haiku[39]);
        payloadWriter.WriteUInt8(s_piDigits[86]);
        payloadWriter.WriteUInt8(s_piDigits[82]);
        payloadWriter.WriteUInt8(haiku[56]);
        payloadWriter.WriteUInt8(s_piDigits[95]);
        payloadWriter.WriteUInt8(hmacResult[18]);
        payloadWriter.WriteUInt8(s_piDigits[113]);
        payloadWriter.WriteUInt8(haiku[38]);
        payloadWriter.WriteUInt8(hmacResult[8]);
        payloadWriter.WriteUInt8(s_piDigits[92]);
        payloadWriter.WriteUInt8(s_piDigits[42]);
        payloadWriter.WriteUInt8(s_piDigits[120]);
        payloadWriter.WriteUInt8(s_piDigits[55]);
        payloadWriter.WriteUInt8(s_piDigits[124]);
        payloadWriter.WriteUInt8(haiku[30]);
        payloadWriter.WriteUInt8(s_piDigits[4]);
        payloadWriter.WriteUInt8(haiku[18]);
        payloadWriter.WriteUInt8(s_piDigits[123]);
        payloadWriter.WriteUInt8(address[8]);
        payloadWriter.WriteUInt8(s_piDigits[61]);
        payloadWriter.WriteUInt8(s_piDigits[122]);
        payloadWriter.WriteUInt8(haiku[19]);
        payloadWriter.WriteUInt8(s_piDigits[53]);
        payloadWriter.WriteUInt8(address[2]);
        payloadWriter.WriteUInt8(hmacResult[11]);
        payloadWriter.WriteUInt8(s_piDigits[31]);
        payloadWriter.WriteUInt8(s_piDigits[36]);
        payloadWriter.WriteUInt8(haiku[2]);
        payloadWriter.WriteUInt8(haiku[57]);
        payloadWriter.WriteUInt8(haiku[40]);
        payloadWriter.WriteUInt8(s_piDigits[70]);
        payloadWriter.WriteUInt8(haiku[34]);
        payloadWriter.WriteUInt8(s_piDigits[132]);
        payloadWriter.WriteUInt8(s_piDigits[20]);
        payloadWriter.WriteUInt8(s_piDigits[107]);
        payloadWriter.WriteUInt8(s_piDigits[141]);
        payloadWriter.WriteUInt8(s_piDigits[97]);
        payloadWriter.WriteUInt8(hmacResult[2]);
        payloadWriter.WriteUInt8(haiku[60]);
        payloadWriter.WriteUInt8(s_piDigits[102]);
        payloadWriter.WriteUInt8(s_piDigits[116]);
        payloadWriter.WriteUInt8(s_piDigits[49]);
        payloadWriter.WriteUInt8(s_piDigits[37]);
        payloadWriter.WriteUInt8(s_piDigits[48]);
        payloadWriter.WriteUInt8(s_piDigits[18]);
        payloadWriter.WriteUInt8(haiku[69]);
        payloadWriter.WriteUInt8(hmacResult[12]);
        payloadWriter.WriteUInt8(s_piDigits[65]);
        payloadWriter.WriteUInt8(hmacResult[3]);
        payloadWriter.WriteUInt8(haiku[27]);
        payloadWriter.WriteUInt8(s_piDigits[118]);
        payloadWriter.WriteUInt8(s_piDigits[44]);
        payloadWriter.WriteUInt8(haiku[50]);
        payloadWriter.WriteUInt8(haiku[59]);
        payloadWriter.WriteUInt8(s_piDigits[81]);
        payloadWriter.WriteUInt8(s_piDigits[51]);
        payloadWriter.WriteUInt8(address[4]);
        payloadWriter.WriteUInt8(s_piDigits[12]);
        payloadWriter.WriteUInt8(s_piDigits[27]);
        payloadWriter.WriteUInt8(address[11]);
        payloadWriter.WriteUInt8(s_piDigits[40]);
        payloadWriter.WriteUInt8(s_piDigits[139]);
        payloadWriter.WriteUInt8(haiku[51]);
        payloadWriter.WriteUInt8(haiku[64]);
        payloadWriter.WriteUInt8(s_piDigits[111]);
        payloadWriter.WriteUInt8(s_piDigits[131]);
        payloadWriter.WriteUInt8(haiku[1]);
        payloadWriter.WriteUInt8(haiku[49]);
        payloadWriter.WriteUInt8(s_piDigits[41]);
        payloadWriter.WriteUInt8(haiku[28]);
        payloadWriter.WriteUInt8(s_piDigits[77]);
        payloadWriter.WriteUInt8(s_piDigits[76]);
        payloadWriter.WriteUInt8(s_piDigits[8]);
        payloadWriter.WriteUInt8(address[12]);
        payloadWriter.WriteUInt8(haiku[62]);
        payloadWriter.WriteUInt8(s_piDigits[19]);
        payloadWriter.WriteUInt8(s_piDigits[17]);
        payloadWriter.WriteUInt8(s_piDigits[24]);
        payloadWriter.WriteUInt8(haiku[72]);
        payloadWriter.WriteUInt8(hmacResult[13]);
        payloadWriter.WriteUInt8(haiku[61]);
        payloadWriter.WriteUInt8(s_piDigits[29]);
        payloadWriter.WriteUInt8(s_piDigits[15]);
        payloadWriter.WriteUInt8(address[7]);
        payloadWriter.WriteUInt8(s_piDigits[121]);
        payloadWriter.WriteUInt8(s_piDigits[69]);
        payloadWriter.WriteUInt8(address[13]);
        payloadWriter.WriteUInt8(haiku[35]);
        payloadWriter.WriteUInt8(s_piDigits[103]);
        payloadWriter.WriteUInt8(s_piDigits[39]);
        payloadWriter.WriteUInt8(hmacResult[5]);
        payloadWriter.WriteUInt8(haiku[4]);
        payloadWriter.WriteUInt8(s_piDigits[34]);
        payloadWriter.WriteUInt8(s_piDigits[56]);
        payloadWriter.WriteUInt8((byte)(port >> 8 & 0xFF));
        payloadWriter.WriteUInt8(hmacResult[10]);
        payloadWriter.WriteUInt8(s_piDigits[80]);
        payloadWriter.WriteUInt8(s_piDigits[130]);
        payloadWriter.WriteUInt8(haiku[12]);
        payloadWriter.WriteUInt8(s_piDigits[134]);
        payloadWriter.WriteUInt8(s_piDigits[33]);
        payloadWriter.WriteUInt8(s_piDigits[25]);
        payloadWriter.WriteUInt8(s_piDigits[73]);
        payloadWriter.WriteUInt8(s_piDigits[138]);
        payloadWriter.WriteUInt8(s_piDigits[9]);
        payloadWriter.WriteUInt8(s_piDigits[66]);
        payloadWriter.WriteUInt8(s_piDigits[1]);
        payloadWriter.WriteUInt8(haiku[45]);
        payloadWriter.WriteUInt8(s_piDigits[126]);
        payloadWriter.WriteUInt8(s_piDigits[67]);
        payloadWriter.WriteUInt8(haiku[33]);
        payloadWriter.WriteUInt8(s_piDigits[10]);
        payloadWriter.WriteUInt8(hmacResult[4]);
        payloadWriter.WriteUInt8(hmacResult[9]);
        payloadWriter.WriteUInt8(haiku[44]);
        payloadWriter.WriteUInt8(s_piDigits[60]);
        payloadWriter.WriteUInt8(s_piDigits[98]);
        payloadWriter.WriteUInt8(s_piDigits[91]);
        payloadWriter.WriteUInt8(hmacResult[1]);
        payloadWriter.WriteUInt8((byte)addressType);
        payloadWriter.WriteUInt8(s_piDigits[11]);
        payloadWriter.WriteUInt8(s_piDigits[83]);
        payloadWriter.WriteUInt8(hmacResult[0]);
        payloadWriter.WriteUInt8(haiku[52]);
        payloadWriter.WriteUInt8(haiku[43]);
        payloadWriter.WriteUInt8(s_piDigits[47]);
        payloadWriter.WriteUInt8(haiku[11]);
        payloadWriter.WriteUInt8(s_piDigits[129]);
        payloadWriter.WriteUInt8(haiku[0]);
        payloadWriter.WriteUInt8(s_piDigits[57]);
        payloadWriter.WriteUInt8(s_piDigits[7]);
        payloadWriter.WriteUInt8(hmacResult[7]);
        payloadWriter.WriteUInt8(haiku[15]);
        payloadWriter.WriteUInt8(haiku[58]);
        payloadWriter.WriteUInt8(haiku[66]);
        payloadWriter.WriteUInt8(s_piDigits[127]);
        payloadWriter.WriteUInt8(haiku[41]);
        payloadWriter.WriteUInt8(address[10]);
        payloadWriter.WriteUInt8(haiku[71]);
        payloadWriter.WriteUInt8(s_piDigits[99]);
        payloadWriter.WriteUInt8(s_piDigits[117]);
        payloadWriter.WriteUInt8(s_piDigits[62]);
        payloadWriter.WriteUInt8(s_piDigits[89]);
        payloadWriter.WriteUInt8(haiku[70]);
        payloadWriter.WriteUInt8(hmacResult[6]);
        payloadWriter.WriteUInt8(s_piDigits[114]);
        payloadWriter.WriteUInt8(s_piDigits[106]);
        payloadWriter.WriteUInt8(s_piDigits[108]);
        payloadWriter.WriteUInt8(haiku[48]);
        payloadWriter.WriteUInt8(haiku[7]);
        payloadWriter.WriteUInt8(s_piDigits[2]);
        payloadWriter.WriteUInt8(s_piDigits[43]);
        payloadWriter.WriteUInt8(haiku[36]);
        payloadWriter.WriteUInt8(s_piDigits[45]);
        payloadWriter.WriteUInt8(s_piDigits[119]);
        payloadWriter.WriteUInt8(haiku[47]);
        payloadWriter.WriteUInt8(haiku[68]);
        payloadWriter.WriteUInt8(hmacResult[16]);
        payloadWriter.WriteUInt8(s_piDigits[128]);
        payloadWriter.WriteUInt8(address[15]);
        payloadWriter.WriteUInt8(s_piDigits[35]);
        payloadWriter.WriteUInt8(s_piDigits[84]);

        // For the actual packet data, we use a new writer
        ServerPacketWriter encryptedPayloadWriter = new();
        encryptedPayloadWriter.WriteUInt64(Key);
        encryptedPayloadWriter.WriteUInt32(Serial);

        // Encrypt the payload
        Span<byte> encryptedPayload = encryptedPayloadWriter.GetSpan(256);
        EncryptWithCRT(payloadWriter.Buffer.AsSpan().Slice(0, payloadWriter.WrittenBytes), encryptedPayload);

        encryptedPayloadWriter.WriteUInt8((byte)Con);

        // After we have encrypted the original payload, we can return the buffer of its payload writer
        payloadWriter.ReturnBuffer();

        payloadLength = encryptedPayloadWriter.WrittenBytes;
        buffer = encryptedPayloadWriter.Buffer;
    }

    private void EncryptWithCRT(ReadOnlySpan<byte> sourcePayload, Span<byte> destinationPayload)
    {
        BigInteger bnData = new(sourcePayload);
        BigInteger p = new(s_P, isUnsigned: true);
        BigInteger q = new(s_Q, isUnsigned: true);
        BigInteger dp = new(s_DP, isUnsigned: true);
        BigInteger dq = new(s_DQ, isUnsigned: true);
        BigInteger iqmp = new(s_InverseQ, isUnsigned: true);

        BigInteger m1 = BigInteger.ModPow(bnData % p, dp, p);
        BigInteger m2 = BigInteger.ModPow(bnData % q, dq, q);
        BigInteger h = iqmp * (m1 - m2) % p;

        if (h.Sign < 0)
            h += p;

        BigInteger m = m2 + h * q;

        destinationPayload.Clear();
        m.TryWriteBytes(destinationPayload, out _, isUnsigned: true);
    }
}
