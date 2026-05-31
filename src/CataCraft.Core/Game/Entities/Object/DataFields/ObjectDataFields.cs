// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers.Binary;
using System.Collections;
using CataCraft.Core.Enums;

namespace CataCraft.Core.Game.Entities.Object.DataFields;

/// <summary>
/// Contains all gameplay related data which is being used to build object update packets.
/// The public methods of this class are only meant to be used by accessor methods implemented in
/// WowObject and its derived classes.
/// </summary>
public sealed class ObjectDataFields
{
    /// The total amount of stored data fields
    public int Count => _dataFields.Length / FieldSize;

    /// The amount blocks which must be built for object update packets
    public int UpdateFieldBlockCount => Count / FieldsPerBlock + (Count % FieldsPerBlock != 0 ? 1 : 0);

    /// A view of the underlying binary data used to store the data fields
    public ReadOnlySpan<byte> Data => _dataFields.AsSpan();

    private const int FieldSize = sizeof(int); // 32 bits per field
    private const int FieldsPerBlock = 32;

    private BitArray? _changedFieldMask;
    private byte[] _dataFields = [];
    private DataFieldVisibilityFlags[]  _visibilityFlags = [];

    /// <summary>
    /// Initializes all data fields required for Unit WowObjects
    /// </summary>
    public void InitializeUnitFields()
    {
        _dataFields =  new byte[(int)EUnitFields.UNIT_END * FieldSize];
        _changedFieldMask = new BitArray((int)EUnitFields.UNIT_END);
        _visibilityFlags = ObjectDataFieldConstants.SUnitVisibilityFlags;
    }

    /// <summary>
    /// Initializes all data fields required for Player WowObjects
    /// </summary>
    public void InitializePlayerFields()
    {
        _dataFields =  new byte[(int)EPlayerFields.PLAYER_END * FieldSize];
        _changedFieldMask = new BitArray((int)EPlayerFields.PLAYER_END);
        _visibilityFlags = ObjectDataFieldConstants.SPlayerVisibilityFlags;
    }

    /// <summary>
    /// Initializes all data fields required for Item WowObjects
    /// </summary>
    public void InitializeItemFields()
    {
        _dataFields = new byte[(int)EItemFields.ITEM_END * FieldSize];
        _changedFieldMask = new BitArray((int)EItemFields.ITEM_END);
    }

    /// <summary>
    /// Initializes all data fields required for GameObject WowObjects
    /// </summary>
    public void InitializeGameObjectFields()
    {
        _dataFields = new byte[(int)EGameObjectFields.GAMEOBJECT_END * FieldSize];
        _changedFieldMask = new BitArray((int)EGameObjectFields.GAMEOBJECT_END);
    }

    private long GetInt64Value(int dataField)
    {
        ReadOnlySpan<byte> field = _dataFields.AsSpan(dataField * FieldSize, FieldSize * 2);
        return BinaryPrimitives.ReadInt64LittleEndian(field);
    }

    public long GetInt64Value(EObjectFields dataField) => GetInt64Value((int)dataField);
    public long GetInt64Value(EUnitFields dataField) => GetInt64Value((int)dataField);
    public long GetInt64Value(EPlayerFields dataField) => GetInt64Value((int)dataField);
    public long GetInt64Value(EItemFields dataField) => GetInt64Value((int)dataField);
    public long GetInt64Value(EGameObjectFields dataField) => GetInt64Value((int)dataField);
    public long GetInt64Value(EAreaTriggerFields dataField) => GetInt64Value((int)dataField);
    public long GetInt64Value(EContainerFields dataField) => GetInt64Value((int)dataField);
    public long GetInt64Value(ECorpseFields dataField) => GetInt64Value((int)dataField);
    public long GetInt64Value(EDynamicObjectFields dataField) => GetInt64Value((int)dataField);

    private ulong GetUInt64Value(int dataField)
    {
        ReadOnlySpan<byte> field = _dataFields.AsSpan(dataField * FieldSize, FieldSize * 2);
        return BinaryPrimitives.ReadUInt64LittleEndian(field);
    }

    public ulong GetInt64UValue(EObjectFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetInt64UValue(EUnitFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetInt64UValue(EPlayerFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetInt64UValue(EItemFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetInt64UValue(EGameObjectFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetInt64UValue(EAreaTriggerFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetInt64UValue(EContainerFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetInt64UValue(ECorpseFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetInt64UValue(EDynamicObjectFields dataField) => GetUInt64Value((int)dataField);

    private int GetInt32Value(int dataField, int arrayIndex = 0)
    {
        ReadOnlySpan<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize);
        return BinaryPrimitives.ReadInt32LittleEndian(field);
    }

    public int GetInt32Value(EObjectFields dataField, int arrayIndex = 0) => GetInt32Value((int)dataField, arrayIndex);
    public int GetInt32Value(EUnitFields dataField, int arrayIndex = 0) => GetInt32Value((int)dataField, arrayIndex);
    public int GetInt32Value(EPlayerFields dataField, int arrayIndex = 0) => GetInt32Value((int)dataField, arrayIndex);
    public int GetInt32Value(EItemFields dataField, int arrayIndex = 0) => GetInt32Value((int)dataField, arrayIndex);
    public int GetInt32Value(EAreaTriggerFields dataField, int arrayIndex = 0) => GetInt32Value((int)dataField, arrayIndex);
    public int GetInt32Value(EContainerFields dataField, int arrayIndex = 0) => GetInt32Value((int)dataField, arrayIndex);
    public int GetInt32Value(ECorpseFields dataField, int arrayIndex = 0) => GetInt32Value((int)dataField, arrayIndex);
    public int GetInt32Value(EDynamicObjectFields dataField, int arrayIndex = 0) => GetInt32Value((int)dataField, arrayIndex);

    private uint GetUInt32Value(int dataField, int arrayIndex = 0)
    {
        ReadOnlySpan<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex, FieldSize);
        return BinaryPrimitives.ReadUInt32LittleEndian(field);
    }

    public uint GetUInt32Value(EObjectFields dataField, int arrayIndex = 0) => GetUInt32Value((int)dataField, arrayIndex);
    public uint GetUInt32Value(EUnitFields dataField, int arrayIndex = 0) => GetUInt32Value((int)dataField, arrayIndex);
    public uint GetUInt32Value(EPlayerFields dataField, int arrayIndex = 0) => GetUInt32Value((int)dataField, arrayIndex);
    public uint GetUInt32Value(EItemFields dataField, int arrayIndex = 0) => GetUInt32Value((int)dataField, arrayIndex);
    public uint GetUInt32Value(EAreaTriggerFields dataField, int arrayIndex = 0) => GetUInt32Value((int)dataField, arrayIndex);
    public uint GetUInt32Value(EContainerFields dataField, int arrayIndex = 0) => GetUInt32Value((int)dataField, arrayIndex);
    public uint GetUInt32Value(ECorpseFields dataField, int arrayIndex = 0) => GetUInt32Value((int)dataField, arrayIndex);
    public uint GetUInt32Value(EDynamicObjectFields dataField, int arrayIndex = 0) => GetUInt32Value((int)dataField, arrayIndex);

    private float GetFloatValue(int dataField, int arrayIndex = 0)
    {
        ReadOnlySpan<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize);
        return BinaryPrimitives.ReadSingleLittleEndian(field);
    }

    public float GetFloatValue(EObjectFields dataField, int arrayIndex = 0) => GetFloatValue((int)dataField, arrayIndex);
    public float GetFloatValue(EUnitFields dataField, int arrayIndex = 0) => GetFloatValue((int)dataField, arrayIndex);
    public float GetFloatValue(EPlayerFields dataField, int arrayIndex = 0) => GetFloatValue((int)dataField, arrayIndex);
    public float GetFloatValue(EItemFields dataField, int arrayIndex = 0) => GetFloatValue((int)dataField, arrayIndex);
    public float GetFloatValue(EAreaTriggerFields dataField, int arrayIndex = 0) => GetFloatValue((int)dataField, arrayIndex);
    public float GetFloatValue(EContainerFields dataField, int arrayIndex = 0) => GetFloatValue((int)dataField, arrayIndex);
    public float GetFloatValue(ECorpseFields dataField, int arrayIndex = 0) => GetFloatValue((int)dataField, arrayIndex);
    public float GetFloatValue(EDynamicObjectFields dataField, int arrayIndex = 0) => GetFloatValue((int)dataField, arrayIndex);

    private short GetInt16Value(int dataField, int arrayIndex = 0, int offset = 0)
    {
        ReadOnlySpan<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize);
        return BinaryPrimitives.ReadInt16LittleEndian(field.Slice(offset * sizeof(short)));
    }

    public short GetInt16Value(EObjectFields dataField, int arrayIndex = 0, int offset = 0) => GetInt16Value((int)dataField, arrayIndex, offset);
    public short GetInt16Value(EUnitFields dataField, int arrayIndex = 0, int offset = 0) => GetInt16Value((int)dataField, arrayIndex, offset);
    public short GetInt16Value(EPlayerFields dataField, int arrayIndex = 0, int offset = 0) => GetInt16Value((int)dataField, arrayIndex, offset);
    public short GetInt16Value(EItemFields dataField, int arrayIndex = 0, int offset = 0) => GetInt16Value((int)dataField, arrayIndex, offset);
    public short GetInt16Value(EAreaTriggerFields dataField, int arrayIndex = 0, int offset = 0) => GetInt16Value((int)dataField, arrayIndex, offset);
    public short GetInt16Value(EContainerFields dataField, int arrayIndex = 0, int offset = 0) => GetInt16Value((int)dataField, arrayIndex, offset);
    public short GetInt16Value(ECorpseFields dataField, int arrayIndex = 0, int offset = 0) => GetInt16Value((int)dataField, arrayIndex, offset);
    public short GetInt16Value(EDynamicObjectFields dataField, int arrayIndex = 0, int offset = 0) => GetInt16Value((int)dataField, arrayIndex, offset);

    private ushort GetUInt16Value(int dataField, int arrayIndex = 0, int offset = 0)
    {
        ReadOnlySpan<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize);
        return BinaryPrimitives.ReadUInt16LittleEndian(field.Slice(offset * sizeof(ushort)));
    }
    public ushort GetUInt16Value(EObjectFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt16Value((int)dataField, arrayIndex, offset);
    public ushort GetUInt16Value(EUnitFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt16Value((int)dataField, arrayIndex, offset);
    public ushort GetUInt16Value(EPlayerFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt16Value((int)dataField, arrayIndex, offset);
    public ushort GetUInt16Value(EItemFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt16Value((int)dataField, arrayIndex, offset);
    public ushort GetUInt16Value(EAreaTriggerFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt16Value((int)dataField, arrayIndex, offset);
    public ushort GetUInt16Value(EContainerFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt16Value((int)dataField, arrayIndex, offset);
    public ushort GetUInt16Value(ECorpseFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt16Value((int)dataField, arrayIndex, offset);
    public ushort GetUInt16Value(EDynamicObjectFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt16Value((int)dataField, arrayIndex, offset);

    private byte GetUInt8Value(int dataField, int arrayIndex = 0, int offset = 0)
    {
        ReadOnlySpan<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize);
        return field[offset];
    }

    public byte GetUInt8Value(EObjectFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt8Value((int)dataField, arrayIndex, offset);
    public byte GetUInt8Value(EUnitFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt8Value((int)dataField, arrayIndex, offset);
    public byte GetUInt8Value(EPlayerFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt8Value((int)dataField, arrayIndex, offset);
    public byte GetUInt8Value(EItemFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt8Value((int)dataField, arrayIndex, offset);
    public byte GetUInt8Value(EAreaTriggerFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt8Value((int)dataField, arrayIndex, offset);
    public byte GetUInt8Value(EContainerFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt8Value((int)dataField, arrayIndex, offset);
    public byte GetUInt8Value(ECorpseFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt8Value((int)dataField, arrayIndex, offset);
    public byte GetUInt8Value(EDynamicObjectFields dataField, int arrayIndex = 0, int offset = 0) => GetUInt8Value((int)dataField, arrayIndex, offset);

    private sbyte GetInt8Value(int dataField, int arrayIndex = 0, int offset = 0)
    {
        ReadOnlySpan<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize);
        return (sbyte)field[offset];
    }

    public sbyte GetInt8Value(EObjectFields dataField, int arrayIndex = 0, int offset = 0) => GetInt8Value((int)dataField, arrayIndex, offset);
    public sbyte GetInt8Value(EUnitFields dataField, int arrayIndex = 0, int offset = 0) => GetInt8Value((int)dataField, arrayIndex, offset);
    public sbyte GetInt8Value(EPlayerFields dataField, int arrayIndex = 0, int offset = 0) => GetInt8Value((int)dataField, arrayIndex, offset);
    public sbyte GetInt8Value(EItemFields dataField, int arrayIndex = 0, int offset = 0) => GetInt8Value((int)dataField, arrayIndex, offset);
    public sbyte GetInt8Value(EAreaTriggerFields dataField, int arrayIndex = 0, int offset = 0) => GetInt8Value((int)dataField, arrayIndex, offset);
    public sbyte GetInt8Value(EContainerFields dataField, int arrayIndex = 0, int offset = 0) => GetInt8Value((int)dataField, arrayIndex, offset);
    public sbyte GetInt8Value(ECorpseFields dataField, int arrayIndex = 0, int offset = 0) => GetInt8Value((int)dataField, arrayIndex, offset);
    public sbyte GetInt8Value(EDynamicObjectFields dataField, int arrayIndex = 0, int offset = 0) => GetInt8Value((int)dataField, arrayIndex, offset);

    private void SetInt64Value(int dataField, long value)
    {
        Span<byte> field = _dataFields.AsSpan(dataField * FieldSize , FieldSize * 2);
        long oldValue = BinaryPrimitives.ReadInt64LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteInt64LittleEndian(field, value);
        _changedFieldMask?.Set(dataField, true);
        _changedFieldMask?.Set(dataField + 1, true);
    }

    public void SetInt64Value(EObjectFields dataField, long value) => SetInt64Value((int)dataField, value);
    public void SetInt64Value(EUnitFields dataField, long value) => SetInt64Value((int)dataField, value);
    public void SetInt64Value(EPlayerFields dataField, long value) => SetInt64Value((int)dataField, value);
    public void SetInt64Value(EItemFields dataField, long value) => SetInt64Value((int)dataField, value);
    public void SetInt64Value(EGameObjectFields dataField, long value) => SetInt64Value((int)dataField, value);
    public void SetInt64Value(EAreaTriggerFields dataField, long value) => SetInt64Value((int)dataField, value);
    public void SetInt64Value(EContainerFields dataField, long value) => SetInt64Value((int)dataField, value);
    public void SetInt64Value(ECorpseFields dataField, long value) => SetInt64Value((int)dataField, value);
    public void SetInt64Value(EDynamicObjectFields dataField, long value) => SetInt64Value((int)dataField, value);

    private void SetUInt64Value(int dataField, ulong value)
    {
        Span<byte> field = _dataFields.AsSpan(dataField * FieldSize, FieldSize * 2);
        ulong oldValue = BinaryPrimitives.ReadUInt64LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteUInt64LittleEndian(field, value);
        _changedFieldMask?.Set(dataField, true);
        _changedFieldMask?.Set(dataField + 1, true);
    }

    public void SetUInt64Value(EObjectFields dataField, ulong value) => SetUInt64Value((int)dataField, value);
    public void SetUInt64Value(EUnitFields dataField, ulong value) => SetUInt64Value((int)dataField, value);
    public void SetUInt64Value(EPlayerFields dataField, ulong value) => SetUInt64Value((int)dataField, value);
    public void SetUInt64Value(EItemFields dataField, ulong value) => SetUInt64Value((int)dataField, value);
    public void SetUInt64Value(EGameObjectFields dataField, ulong value) => SetUInt64Value((int)dataField, value);
    public void SetUInt64Value(EAreaTriggerFields dataField, ulong value) => SetUInt64Value((int)dataField, value);
    public void SetUInt64Value(EContainerFields dataField, ulong value) => SetUInt64Value((int)dataField, value);
    public void SetUInt64Value(ECorpseFields dataField, ulong value) => SetUInt64Value((int)dataField, value);
    public void SetUInt64Value(EDynamicObjectFields dataField, ulong value) => SetUInt64Value((int)dataField, value);

    private void SetInt32Value(int dataField, int arrayIndex, int value)
    {
        Span<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize);
        int oldValue = BinaryPrimitives.ReadInt32LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteInt32LittleEndian(field, value);
        _changedFieldMask?.Set(dataField + arrayIndex, true);
    }

    public void SetUInt32Value(EObjectFields dataField, int arrayIndex, uint value) => SetUInt32Value((int)dataField, arrayIndex, value);
    public void SetUInt32Value(EUnitFields dataField, int arrayIndex,  uint value) => SetUInt32Value((int)dataField, arrayIndex, value);
    public void SetUInt32Value(EPlayerFields dataField, int arrayIndex, uint value) => SetUInt32Value((int)dataField, arrayIndex, value);
    public void SetUInt32Value(EItemFields dataField, int arrayIndex, uint value) => SetUInt32Value((int)dataField, arrayIndex, value);
    public void SetUInt32Value(EGameObjectFields dataField, int arrayIndex, uint value) => SetUInt32Value((int)dataField, arrayIndex, value);
    public void SetUInt32Value(EAreaTriggerFields dataField, int arrayIndex, uint value) => SetUInt32Value((int)dataField, arrayIndex, value);
    public void SetUInt32Value(EContainerFields dataField, int arrayIndex, uint value) => SetUInt32Value((int)dataField, arrayIndex, value);
    public void SetUInt32Value(ECorpseFields dataField, int arrayIndex, uint value) => SetUInt32Value((int)dataField, arrayIndex, value);
    public void SetUInt32Value(EDynamicObjectFields dataField, int arrayIndex, uint value) => SetUInt32Value((int)dataField, arrayIndex, value);

    private void SetUInt32Value(int dataField, int arrayIndex, uint value)
    {
        Span<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize);
        uint oldValue = BinaryPrimitives.ReadUInt32LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteUInt32LittleEndian(field, value);
        _changedFieldMask?.Set(dataField + arrayIndex, true);
    }

    public void SetInt32Value(EObjectFields dataField, int arrayIndex, int value) => SetInt32Value((int)dataField, arrayIndex, value);
    public void SetInt32Value(EUnitFields dataField, int arrayIndex, int value) => SetInt32Value((int)dataField, arrayIndex, value);
    public void SetInt32Value(EPlayerFields dataField, int arrayIndex, int value) => SetInt32Value((int)dataField, arrayIndex, value);
    public void SetInt32Value(EItemFields dataField, int arrayIndex, int value) => SetInt32Value((int)dataField, arrayIndex, value);
    public void SetInt32Value(EGameObjectFields dataField, int arrayIndex, int value) => SetInt32Value((int)dataField, arrayIndex, value);
    public void SetInt32Value(EAreaTriggerFields dataField, int arrayIndex, int value) => SetInt32Value((int)dataField, arrayIndex, value);
    public void SetInt32Value(EContainerFields dataField, int arrayIndex, int value) => SetInt32Value((int)dataField, arrayIndex, value);
    public void SetInt32Value(ECorpseFields dataField, int arrayIndex, int value) => SetInt32Value((int)dataField, arrayIndex, value);
    public void SetInt32Value(EDynamicObjectFields dataField, int arrayIndex, int value) => SetInt32Value((int)dataField, arrayIndex, value);

    private void SetFloatValue(int dataField, int arrayIndex, float value)
    {
        Span<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize);
        float oldValue = BinaryPrimitives.ReadSingleLittleEndian(field);
        if (MathF.Abs(oldValue - value) <= 0.00001f)
            return;

        BinaryPrimitives.WriteSingleLittleEndian(field, value);
        _changedFieldMask?.Set(dataField + arrayIndex, true);
    }

    public void SetFloatValue(EObjectFields dataField, int arrayIndex, float value) => SetFloatValue((int)dataField, arrayIndex, value);
    public void SetFloatValue(EUnitFields dataField, int arrayIndex,  float value) => SetFloatValue((int)dataField, arrayIndex, value);
    public void SetFloatValue(EPlayerFields dataField, int arrayIndex, float value) => SetFloatValue((int)dataField, arrayIndex, value);
    public void SetFloatValue(EItemFields dataField, int arrayIndex, float value) => SetFloatValue((int)dataField, arrayIndex, value);
    public void SetFloatValue(EGameObjectFields dataField, int arrayIndex, float value) => SetFloatValue((int)dataField, arrayIndex, value);
    public void SetFloatValue(EAreaTriggerFields dataField, int arrayIndex, float value) => SetFloatValue((int)dataField, arrayIndex, value);
    public void SetFloatValue(EContainerFields dataField, int arrayIndex, float value) => SetFloatValue((int)dataField, arrayIndex, value);
    public void SetFloatValue(ECorpseFields dataField, int arrayIndex, float value) => SetFloatValue((int)dataField, arrayIndex, value);
    public void SetFloatValue(EDynamicObjectFields dataField, int arrayIndex, float value) => SetFloatValue((int)dataField, arrayIndex, value);

    private void SetInt16Value(int dataField, int arrayIndex, int offset, short value)
    {
        Span<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize).Slice(offset * sizeof(short), sizeof(short));
        short oldValue = BinaryPrimitives.ReadInt16LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteInt16LittleEndian(field, value);
        _changedFieldMask?.Set(dataField + arrayIndex, true);
    }

    public void SetInt16Value(EObjectFields dataField, int arrayIndex, int offset, short value) => SetInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetInt16Value(EUnitFields dataField, int arrayIndex, int offset, short value) => SetInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetInt16Value(EPlayerFields dataField, int arrayIndex, int offset, short value) => SetInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetInt16Value(EItemFields dataField, int arrayIndex, int offset, short value) => SetInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetInt16Value(EGameObjectFields dataField, int arrayIndex, int offset, short value) => SetInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetInt16Value(EAreaTriggerFields dataField, int arrayIndex, int offset, short value) => SetInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetInt16Value(EContainerFields dataField, int arrayIndex, int offset, short value) => SetInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetInt16Value(ECorpseFields dataField, int arrayIndex, int offset, short value) => SetInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetInt16Value(EDynamicObjectFields dataField, int arrayIndex, int offset, short value) => SetInt16Value((int)dataField, arrayIndex, offset, value);

    private void SetUInt16Value(int dataField, int arrayIndex, int offset, ushort value)
    {
        Span<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize).Slice(offset * sizeof(ushort), sizeof(ushort));
        ushort oldValue = BinaryPrimitives.ReadUInt16LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteUInt16LittleEndian(field, value);
        _changedFieldMask?.Set(dataField + arrayIndex, true);
    }

    public void SetUInt16Value(EObjectFields dataField, int arrayIndex, int offset, ushort value) => SetUInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt16Value(EUnitFields dataField, int arrayIndex, int offset, ushort value) => SetUInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt16Value(EPlayerFields dataField, int arrayIndex, int offset, ushort value) => SetUInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt16Value(EItemFields dataField, int arrayIndex, int offset, ushort value) => SetUInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt16Value(EGameObjectFields dataField, int arrayIndex, int offset, ushort value) => SetUInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt16Value(EAreaTriggerFields dataField, int arrayIndex, int offset, ushort value) => SetUInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt16Value(EContainerFields dataField, int arrayIndex, int offset, ushort value) => SetUInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt16Value(ECorpseFields dataField, int arrayIndex, int offset, ushort value) => SetUInt16Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt16Value(EDynamicObjectFields dataField, int arrayIndex, int offset, ushort value) => SetUInt16Value((int)dataField, arrayIndex, offset, value);

    private void SetUInt8Value(int dataField, int arrayIndex, int offset, byte value)
    {
        Span<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize).Slice(offset * sizeof(byte), sizeof(byte));
        byte oldValue = field[0];
        if (oldValue == value)
            return;

        field[0] = value;
        _changedFieldMask?.Set(dataField + arrayIndex, true);
    }

    public void SetUInt8Value(EObjectFields dataField, int arrayIndex, int offset, byte value) => SetUInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt8Value(EUnitFields dataField, int arrayIndex, int offset, byte value) => SetUInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt8Value(EPlayerFields dataField, int arrayIndex, int offset, byte value) => SetUInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt8Value(EItemFields dataField, int arrayIndex, int offset, byte value) => SetUInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt8Value(EGameObjectFields dataField, int arrayIndex, int offset, byte value) => SetUInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt8Value(EAreaTriggerFields dataField, int arrayIndex, int offset, byte value) => SetUInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt8Value(EContainerFields dataField, int arrayIndex, int offset, byte value) => SetUInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt8Value(ECorpseFields dataField, int arrayIndex, int offset, byte value) => SetUInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetUInt8Value(EDynamicObjectFields dataField, int arrayIndex, int offset, byte value) => SetUInt8Value((int)dataField, arrayIndex, offset, value);

    private void SetInt8Value(int dataField, int arrayIndex, int offset, sbyte value)
    {
        Span<byte> field = _dataFields.AsSpan(dataField * FieldSize + arrayIndex * FieldSize, FieldSize).Slice(offset * sizeof(sbyte), sizeof(sbyte));
        sbyte oldValue = (sbyte)field[0];
        if (oldValue == value)
            return;

        field[0] = (byte)value;
        _changedFieldMask?.Set(dataField + arrayIndex, true);
    }

    public void SetInt8Value(EObjectFields dataField, int arrayIndex, int offset, sbyte value) => SetInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetInt8Value(EUnitFields dataField, int arrayIndex, int offset, sbyte value) => SetInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetInt8Value(EPlayerFields dataField, int arrayIndex, int offset, sbyte value) => SetInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetInt8Value(EItemFields dataField, int arrayIndex, int offset, sbyte value) => SetInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetInt8Value(EGameObjectFields dataField, int arrayIndex, int offset, sbyte value) => SetInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetInt8Value(EAreaTriggerFields dataField, int arrayIndex, int offset, sbyte value) => SetInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetInt8Value(EContainerFields dataField, int arrayIndex, int offset, sbyte value) => SetInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetInt8Value(ECorpseFields dataField, int arrayIndex, int offset, sbyte value) => SetInt8Value((int)dataField, arrayIndex, offset, value);
    public void SetInt8Value(EDynamicObjectFields dataField, int arrayIndex, int offset, sbyte value) => SetInt8Value((int)dataField, arrayIndex, offset, value);

    public bool HasBeenModified(int dataField)
    {
        return _changedFieldMask != null && _changedFieldMask[dataField];
    }

    public bool IsVisible(int dataField, DataFieldVisibilityFlags visibilityFlags)
    {
        return (int)(_visibilityFlags[dataField] & visibilityFlags) != 0;
    }
}
