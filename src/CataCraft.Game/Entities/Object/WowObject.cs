// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object;

public abstract class WowObject : MirroredObject
{
    // Properties
    public bool IsNewObject { get; set; }

    #region Update Field Accessors

    public WowGuid Guid
    {
        get => GetUInt64Value(EObjectFields.OBJECT_FIELD_GUID);
        private init => SetUInt64Value(EObjectFields.OBJECT_FIELD_GUID, value);
    }

    public WowGuid GuidData
    {
        get => GetUInt64Value(EObjectFields.OBJECT_FIELD_DATA);
        set=> SetUInt64Value(EObjectFields.OBJECT_FIELD_DATA, value);
    }

    public TypeMask ObjectType
    {
        get => (TypeMask)GetUInt16Value(EObjectFields.OBJECT_FIELD_TYPE);
        init => SetUInt16Value(EObjectFields.OBJECT_FIELD_TYPE, 0, 0, (ushort)value);
    }

    public bool HasGuildData
    {
        get => GetUInt16Value(EObjectFields.OBJECT_FIELD_TYPE, 0, 1) != 0;
        set => SetUInt16Value(EObjectFields.OBJECT_FIELD_TYPE, 0, 1, (ushort)(value ? 1 : 0));
    }

    public float ScaleX
    {
        get => GetFloatValue(EObjectFields.OBJECT_FIELD_SCALE_X);
        set => SetFloatValue(EObjectFields.OBJECT_FIELD_SCALE_X, 0, value);
    }

    public int Entry
    {
        get => GetUInt16Value(EObjectFields.OBJECT_FIELD_ENTRY);
        set => SetInt32Value(EObjectFields.OBJECT_FIELD_ENTRY, 0, value);
    }

    #endregion // Update Field Accessors

    protected WowObject(WowGuid guid, int updateFieldCount, DataFieldVisibilityFlags[] updateFieldVisibilityFlags) : base(updateFieldCount, updateFieldVisibilityFlags)
    {
        Guid = guid;
        IsNewObject = true;
        ObjectType |= TypeMask.Object;
        ScaleX = 1f;
    }

    public abstract void Update();
    public abstract void Heartbeat();
}
