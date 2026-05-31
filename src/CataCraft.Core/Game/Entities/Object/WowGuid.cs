// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers.Binary;
using CataCraft.Core.Enums;

namespace CataCraft.Core.Game.Entities.Object
{

    [Flags]
    public enum TypeMask
    {
        Object          = 0x0001,
        Item            = 0x0002,
        Container       = 0x0006, // ITEM | 0x0004
        Unit            = 0x0008, // creature
        Player          = 0x0010,
        GameObject      = 0x0020,
        DynamicObject   = 0x0040,
        Corpse          = 0x0080,
        AreaTrigger     = 0x0100,
        Seer = Player | Unit | DynamicObject
    }

    public struct WowGuid : IEquatable<WowGuid>
    {
        public static implicit operator ulong(WowGuid guid)
        {
            return guid.RawValue;
        }

        public static implicit operator WowGuid(ulong raw)
        {
            return new WowGuid(raw);
        }

        public static implicit operator WowGuid(byte[] bytes)
        {
            return new WowGuid(BinaryPrimitives.ReadUInt64LittleEndian(bytes));
        }

        public static readonly WowGuid Empty = new(0);

        public ulong RawValue { get; private set; }
        public uint Counter => (uint)(RawValue & 0xFFFFFFFF);
        public uint Entry => (uint)(RawValue >> 32 & 0xFFFFF);
        public bool IsEmpty => RawValue == 0;

        public bool IsPlayer => !IsEmpty && GuidType == WowGuidType.Player;
        public bool IsUnit => GuidType == WowGuidType.Unit;
        public bool IsItem => GuidType == WowGuidType.Item;
        public bool IsContainer => GuidType == WowGuidType.Container;
        public bool IsVehicle => GuidType == WowGuidType.Vehicle;
        public bool IsPet =>  GuidType == WowGuidType.Pet;
        public bool IsGameObject => GuidType == WowGuidType.GameObject;
        public bool IsDynamicObject => GuidType == WowGuidType.DynamicObject;
        public bool IsCorpse => GuidType == WowGuidType.Corpse;
        public bool IsAreaTrigger => GuidType == WowGuidType.AreaTrigger;

        public WowGuidType GuidType
        {
            get
            {
                WowGuidType temp = (WowGuidType)(RawValue >> 48 & 0xFFFF);
                return temp == WowGuidType.Corpse || temp == WowGuidType.AreaTrigger ? temp : (WowGuidType)((uint)temp >> 4 & 0xFFF);
            }
        }

        public WowObjectType ObjectType
        {
            get
            {
                switch (GuidType)
                {
                    case WowGuidType.Item:
                        return WowObjectType.Item;
                    case WowGuidType.Unit:
                    case WowGuidType.Pet:
                    case WowGuidType.Vehicle:
                        return WowObjectType.Unit;
                    case WowGuidType.Player:
                        return WowObjectType.Player;
                    case WowGuidType.GameObject:
                        return WowObjectType.GameObject;
                    case WowGuidType.DynamicObject:
                        return WowObjectType.DynamicObject;
                    case WowGuidType.Corpse:
                        return WowObjectType.Corpse;
                    case WowGuidType.AreaTrigger:
                        return WowObjectType.AreaTrigger;
                    case WowGuidType.Mo_Transport:
                        return WowObjectType.GameObject;
                    default:
                        return WowObjectType.Object;
                }
            }
        }

        public bool HasEntry
        {
            get
            {
                switch (GuidType)
                {
                    case WowGuidType.Item:
                    case WowGuidType.Player:
                    case WowGuidType.DynamicObject:
                    case WowGuidType.Corpse:
                    case WowGuidType.Mo_Transport:
                    case WowGuidType.Instance:
                    case WowGuidType.Group:
                        return false;
                    default:
                        return true;
                }
            }
        }

        public WowGuid()
        {
            RawValue = 0;
        }

        public WowGuid(ulong guid)
        {
            RawValue = guid;
        }

        public WowGuid(WowGuidType high, uint entry, uint counter)
        {
            RawValue = counter != 0 ? counter | (ulong)entry << 32 | (ulong)high << (high == WowGuidType.Corpse || high == WowGuidType.AreaTrigger ? 48 : 52) : 0;
        }

        public WowGuid(WowGuidType high, uint counter)
        {
            RawValue = counter != 0 ? counter | (ulong)high << (high == WowGuidType.Corpse || high == WowGuidType.AreaTrigger ? 48 : 52) : 0;
        }

        public override string ToString()
        {
            return $"0x{RawValue:X16}";
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index > 7)
                    throw new ArgumentOutOfRangeException("index must be within byte range (0 - 7)");

                return (byte)(RawValue >> index * 8 & 0xFF);
            }

            set
            {
                if (index < 0 || index > 7)
                    throw new ArgumentOutOfRangeException("index must be within byte range (0 - 7)");

                RawValue &= ~(0xFFUL << index * 8);
                RawValue |= (ulong)value << index * 8;
            }
        }

        public bool Equals(WowGuid other) => RawValue == other.RawValue;
    }

    public sealed class PackedGuid
    {
        private const int PacketGuidMinBufferSize = 9;
        private readonly byte[] _packedGuid = new byte[PacketGuidMinBufferSize];
        private int _packedSize;

        public int Size => _packedSize;

        public PackedGuid()
        {
            _packedSize = 1;
        }

        public PackedGuid(WowGuid guid)
        {
            Set(guid);
        }

        public void Set(WowGuid guid)
        {
            _packedSize = 1;
            ulong raw = guid.RawValue;

            for (byte i = 0; i < 8; ++i)
            {
                byte val = (byte)(raw >> i * 8 & 0xFF);
                if (val != 0)
                {
                    _packedGuid[0] |= (byte)(1 << i);
                    ++_packedSize;
                }
            }
        }
    }
}
