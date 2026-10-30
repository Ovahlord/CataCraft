// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers.Binary;
using System.Collections;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object;

public abstract class MirroredObject
{
    public const int UpdateFieldSize = sizeof(int); // One update field is 32 bits large. 64bit values are stored over two fields
    public const int FieldsPerBlock = 32; // One update field block contains 32 fields

    public int UpdateFieldCount => _objectData.Length / UpdateFieldSize;
    public int UpdateFieldBlockCount => UpdateFieldCount / FieldsPerBlock + (UpdateFieldCount % FieldsPerBlock != 0 ? 1 : 0);
    public bool HasDirtyUpdateFields => _dirtyMask.HasAnySet();

    private readonly byte[] _objectData;
    private readonly BitArray _dirtyMask;
    private readonly DataFieldVisibilityFlags[] _visibilityFlags;

    public MirroredObject(int updateFieldCount, DataFieldVisibilityFlags[] visibilityFlags)
    {
        _objectData = new byte[updateFieldCount * UpdateFieldSize];
        _dirtyMask = new BitArray(updateFieldCount);
        _visibilityFlags = visibilityFlags;
    }

    public bool IsUpdateFieldDirty(int index) => _dirtyMask[index];
    public bool IsUpdateFieldVisible(int index, DataFieldVisibilityFlags visibilityFlags) => (int)(_visibilityFlags[index] & visibilityFlags) != 0;
    public void ClearDirtyUpdateFields() => _dirtyMask.SetAll(false);
    public ReadOnlySpan<byte> UpdateFieldData(int index) => _objectData.AsSpan(index * UpdateFieldSize, UpdateFieldSize);

    #region Update Field Accessors

    private long GetInt64Value(int dataField)
    {
        ReadOnlySpan<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize, UpdateFieldSize * 2);
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
        ReadOnlySpan<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize, UpdateFieldSize * 2);
        return BinaryPrimitives.ReadUInt64LittleEndian(field);
    }

    public ulong GetUInt64Value(EObjectFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetUInt64Value(EUnitFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetUInt64Value(EPlayerFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetUInt64Value(EItemFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetUInt64Value(EGameObjectFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetUInt64Value(EAreaTriggerFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetUInt64Value(EContainerFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetUInt64Value(ECorpseFields dataField) => GetUInt64Value((int)dataField);
    public ulong GetUInt64Value(EDynamicObjectFields dataField) => GetUInt64Value((int)dataField);

    private int GetInt32Value(int dataField, int arrayIndex = 0)
    {
        ReadOnlySpan<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize);
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
        ReadOnlySpan<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex, UpdateFieldSize);
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
        ReadOnlySpan<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize);
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
        ReadOnlySpan<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize);
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
        ReadOnlySpan<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize);
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
        ReadOnlySpan<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize);
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
        ReadOnlySpan<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize);
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
        Span<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize , UpdateFieldSize * 2);
        long oldValue = BinaryPrimitives.ReadInt64LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteInt64LittleEndian(field, value);
        _dirtyMask.Set(dataField, true);
        _dirtyMask.Set(dataField + 1, true);
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
        Span<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize, UpdateFieldSize * 2);
        ulong oldValue = BinaryPrimitives.ReadUInt64LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteUInt64LittleEndian(field, value);
        _dirtyMask.Set(dataField, true);
        _dirtyMask.Set(dataField + 1, true);
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
        Span<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize);
        int oldValue = BinaryPrimitives.ReadInt32LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteInt32LittleEndian(field, value);
        _dirtyMask.Set(dataField + arrayIndex, true);
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
        Span<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize);
        uint oldValue = BinaryPrimitives.ReadUInt32LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteUInt32LittleEndian(field, value);
        _dirtyMask.Set(dataField + arrayIndex, true);
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
        Span<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize);
        float oldValue = BinaryPrimitives.ReadSingleLittleEndian(field);
        if (MathF.Abs(oldValue - value) <= 0.00001f)
            return;

        BinaryPrimitives.WriteSingleLittleEndian(field, value);
        _dirtyMask.Set(dataField + arrayIndex, true);
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
        Span<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize).Slice(offset * sizeof(short), sizeof(short));
        short oldValue = BinaryPrimitives.ReadInt16LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteInt16LittleEndian(field, value);
        _dirtyMask.Set(dataField + arrayIndex, true);
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
        Span<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize).Slice(offset * sizeof(ushort), sizeof(ushort));
        ushort oldValue = BinaryPrimitives.ReadUInt16LittleEndian(field);
        if (oldValue == value)
            return;

        BinaryPrimitives.WriteUInt16LittleEndian(field, value);
        _dirtyMask.Set(dataField + arrayIndex, true);
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
        Span<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize).Slice(offset * sizeof(byte), sizeof(byte));
        byte oldValue = field[0];
        if (oldValue == value)
            return;

        field[0] = value;
        _dirtyMask.Set(dataField + arrayIndex, true);
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
        Span<byte> field = _objectData.AsSpan(dataField * UpdateFieldSize + arrayIndex * UpdateFieldSize, UpdateFieldSize).Slice(offset * sizeof(sbyte), sizeof(sbyte));
        sbyte oldValue = (sbyte)field[0];
        if (oldValue == value)
            return;

        field[0] = (byte)value;
        _dirtyMask.Set(dataField + arrayIndex, true);
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

    #endregion
}
