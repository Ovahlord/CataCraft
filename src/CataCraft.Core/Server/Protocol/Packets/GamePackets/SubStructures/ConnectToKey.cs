// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

public struct ConnectToKey(ulong key)
{
    private ulong raw = key; // Represents the raw 64-bit value

    // Properties to access the fields
    public uint AccountId
    {
        get => (uint)(raw & 0xFFFFFFFF); // Extract the lower 32 bits
        set => raw = raw & ~0xFFFFFFFFUL | value & 0xFFFFFFFFUL;
    }

    public ConnectToConnectionType ConnectionType
    {
        get => (ConnectToConnectionType)(byte)(raw >> 32 & 0x1); // Extract the 33rd bit (bit 32) as a byte
        set => raw = raw & ~(0x1UL << 32) | (ulong)((byte)value & 0x1) << 32;
    }

    public uint Key
    {
        get => (uint)(raw >> 33 & 0x7FFFFFFF); // Extract bits 33-63 (31 bits)
        set => raw = raw & ~(0x7FFFFFFFUL << 33) | (value & 0x7FFFFFFFUL) << 33;
    }

    // Property to access the raw 64-bit value
    public ulong Raw
    {
        get => raw;
        set => raw = value;
    }
}
