// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Game.World.Entities.Object.DataFields;

namespace CataCraft.Core.Game.World.Entities.Object;

public abstract class WowObject
{
    public WowGuid Guid { get; private set; }
    public ObjectDataFields DataFields { get; private set; } = new();
    public MovementStatus MovementStatus { get; private set; } = new();
    public virtual bool IsWorldObject => false;

    protected WowObject(WowGuid guid)
    {
        Guid = guid;
        if (Guid.IsPlayer)
        {
            DataFields.InitializePlayerFields();
            DataFields.SetUInt32Value(EObjectFields.OBJECT_FIELD_TYPE, 0, 65561);
            DataFields.SetFloatValue(EObjectFields.OBJECT_FIELD_SCALE_X, 0, 1);
        }
        else if (Guid.IsUnit)
        {
            DataFields.InitializeUnitFields();
        }

        DataFields.SetUInt64Value(EObjectFields.OBJECT_FIELD_GUID, guid);
    }
}
