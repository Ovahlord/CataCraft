// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Enums;

namespace CataCraft.Game.Entities.Object;

public abstract class WowObject : MirroredObject
{
    #region Update Field Accessors

    public WowGuid Guid
    {
        get => GetUInt64Value(EObjectFields.OBJECT_FIELD_GUID);
        private init => SetUInt64Value(EObjectFields.OBJECT_FIELD_GUID, value);
    }

    public TypeMask ObjectType
    {
        get => (TypeMask)GetUInt16Value(EObjectFields.OBJECT_FIELD_TYPE);
        init => SetUInt16Value(EObjectFields.OBJECT_FIELD_TYPE, 0, 0, (ushort)value);
    }

    public float ScaleX
    {
        get => GetFloatValue(EObjectFields.OBJECT_FIELD_SCALE_X);
        set => SetFloatValue(EObjectFields.OBJECT_FIELD_SCALE_X, 0, value);
    }

    public int Entry
    {
        get => GetInt32Value(EObjectFields.OBJECT_FIELD_ENTRY);
        set => SetInt32Value(EObjectFields.OBJECT_FIELD_ENTRY, 0, value);
    }

    #endregion // Update Field Accessors

    public bool IsNewObject { get; set; }

    protected WowObject(WowGuid guid, int updateFieldCount, DataFieldVisibilityFlags[] updateFieldVisibilityFlags) : base(updateFieldCount, updateFieldVisibilityFlags)
    {
        Guid = guid;
        ObjectType |= TypeMask.Object;
        ScaleX = 1f;
    }

    public abstract void Update();
    public abstract void Heartbeat();
}
