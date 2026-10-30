// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Server.Protocol.Packets;
using CataCraft.Game.Entities.Object;
using CataCraft.Game.Entities.Unit;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ServerUpdateObject : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_UPDATE_OBJECT;

    public bool HasObjectsToUpdate => _outOfRangeObjectGuids.Count > 0 || _objectsToUpdate.Count > 0 || _objectsToCreate.Count > 0;

    private struct ObjectToUpdate
    {
        public WowObject Object { get; set; }
        public DataFieldVisibilityFlags VisibilityFlags { get; set; }
    }

    private struct ObjectToCreate
    {
        public WowObject Object { get; set; }
        public CreateObjectBits CreateObjectBits { get; set; }
        public bool NewSpawn { get; set; }
        public DataFieldVisibilityFlags VisibilityFlags { get; set; }
    }

    public ushort MapRecId { get; set; }
    private readonly List<WowGuid> _outOfRangeObjectGuids = [];
    private readonly List<ObjectToUpdate> _objectsToUpdate = [];
    private readonly List<ObjectToCreate> _objectsToCreate = [];

    public ServerUpdateObject()
    {
    }

    public void AddObjectToUpdate(WowObject obectToUpdate, DataFieldVisibilityFlags visibilityFlags)
    {
        _objectsToUpdate.Add(new ObjectToUpdate()
        {
            Object = obectToUpdate,
            VisibilityFlags = visibilityFlags
        });
    }

    public void AddObjectToCreate(WowObject objectToCreate, DataFieldVisibilityFlags visibilityFlags, CreateObjectBits createObjectBits)
    {
        _objectsToCreate.Add(new ObjectToCreate()
        {
            Object = objectToCreate,
            CreateObjectBits = createObjectBits,
            NewSpawn = objectToCreate.IsNewObject,
            VisibilityFlags = visibilityFlags
        });
    }

    public void AddOutOfRangeObject(WowObject objectOutOfRange)
    {
        _outOfRangeObjectGuids.Add(objectOutOfRange.Guid);
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteUInt16(MapRecId);
        writer.WriteInt32(_objectsToCreate.Count + _objectsToUpdate.Count + _outOfRangeObjectGuids.Count);

        if (_outOfRangeObjectGuids.Count != 0)
        {
            writer.WriteUInt8((byte)ObjectUpdateType.OutOfRangeObjects);
            writer.WriteUInt32((uint)_outOfRangeObjectGuids.Count);

            foreach (WowGuid outOfRangeGuid in _outOfRangeObjectGuids)
                writer.WritePackGUID(outOfRangeGuid);
        }

        foreach (ObjectToCreate objectToCreate in _objectsToCreate)
        {
            writer.WriteUInt8((byte)(objectToCreate.NewSpawn ? ObjectUpdateType.CreateObject2 : ObjectUpdateType.CreateObject));
            writer.WritePackGUID(objectToCreate.Object.Guid);
            writer.WriteUInt8((byte)objectToCreate.Object.Guid.ObjectType);

            WriteCreateObjectBlock(ref writer, objectToCreate.Object, objectToCreate.CreateObjectBits);
            WriteUpdateFields(ref writer, objectToCreate.Object, objectToCreate.VisibilityFlags);
        }

        foreach (ObjectToUpdate objectToUpdate in _objectsToUpdate)
        {
            writer.WriteUInt8((byte)ObjectUpdateType.Values);
            writer.WritePackGUID(objectToUpdate.Object.Guid);
            WriteUpdateFields(ref writer, objectToUpdate.Object, objectToUpdate.VisibilityFlags);
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }

    private void WriteCreateObjectBlock(ref ServerPacketWriter writer, WowObject wowObject, CreateObjectBits createObjectBits)
    {
        List<uint> pauseTimes = []; // @todo

        writer.WriteBit(createObjectBits.PlayHoverAnim);
        writer.WriteBit(createObjectBits.SupressedGreetings);
        writer.WriteBit(createObjectBits.Rotation);
        writer.WriteBit(createObjectBits.AnimKit);
        writer.WriteBit(createObjectBits.CombatVictim);
        writer.WriteBit(createObjectBits.ThisIsYou);
        writer.WriteBit(createObjectBits.Vehicle);
        writer.WriteBit(createObjectBits.MovementUpdate);
        writer.WriteBits((uint)pauseTimes.Count, 24);
        writer.WriteBit(createObjectBits.NoBirthAnim);
        writer.WriteBit(createObjectBits.MovementTransport);
        writer.WriteBit(createObjectBits.Stationary);
        writer.WriteBit(createObjectBits.AreaTrigger);
        writer.WriteBit(createObjectBits.EnablePortals);
        writer.WriteBit(createObjectBits.ServerTime);

        if (createObjectBits.MovementUpdate)
        {
            if (wowObject is not UnitBase unit)
                throw new Exception($"CreateObjectBits.MovementUpdate can only be used for Units but has been used incorrectly for WowObject (GUID: {wowObject.Guid})");

            writer.WriteBit(unit.MovementStatus.MovementFlags0 == MovementFlags0.None);
            writer.WriteBit(unit.MovementStatus.Facing == 0f);
            writer.WriteBit(unit.Guid[7]);
            writer.WriteBit(unit.Guid[3]);
            writer.WriteBit(unit.Guid[2]);

            if (unit.MovementStatus.MovementFlags0 != MovementFlags0.None)
                writer.WriteBits((uint)unit.MovementStatus.MovementFlags0, 30);

            writer.WriteBit(false); // hasSpline && !self->IsPlayer() - !Has player spline data
            writer.WriteBit(true); // !Has pitch
            writer.WriteBit(false); // Has spline data (independent)
            writer.WriteBit(unit.MovementStatus.Fall != null);
            writer.WriteBit(true); // !Has spline elevation
            writer.WriteBit(unit.Guid[5]);
            writer.WriteBit(unit.MovementStatus.Transport != null);
            writer.WriteBit(unit.MovementStatus.MoveTime == 0);

            if (unit.MovementStatus.Transport != null)
            {
                writer.WriteBit(unit.MovementStatus.Transport.Guid[1]);
                writer.WriteBit(unit.MovementStatus.Transport.PrevMoveTime.HasValue);
                writer.WriteBit(unit.MovementStatus.Transport.Guid[4]);
                writer.WriteBit(unit.MovementStatus.Transport.Guid[0]);
                writer.WriteBit(unit.MovementStatus.Transport.Guid[6]);
                writer.WriteBit(unit.MovementStatus.Transport.VehicleRecID.HasValue);
                writer.WriteBit(unit.MovementStatus.Transport.Guid[7]);
                writer.WriteBit(unit.MovementStatus.Transport.Guid[5]);
                writer.WriteBit(unit.MovementStatus.Transport.Guid[3]);
                writer.WriteBit(unit.MovementStatus.Transport.Guid[2]);
            }

            writer.WriteBit(unit.Guid[4]);

            //if (hasSpline)
            //    Movement::PacketBuilder::WriteCreateBits(*self->movespline, *data);

            writer.WriteBit(unit.Guid[6]);

            if (unit.MovementStatus.Fall != null)
                writer.WriteBit(unit.MovementStatus.Fall.Velocity != null);

            writer.WriteBit(unit.Guid[0]);
            writer.WriteBit(unit.Guid[1]);
            writer.WriteBit(unit.MovementStatus.HeightChangeFailed);
            writer.WriteBit(unit.MovementStatus.MovementFlags1 == MovementFlags1.None);

            if (unit.MovementStatus.MovementFlags1 != MovementFlags1.None)
                writer.WriteBits((uint)unit.MovementStatus.MovementFlags1, 12);
        }

        if (createObjectBits.MovementTransport)
        {
            if (wowObject is not WorldObject worldObject)
                throw new Exception($"CreateObjectBits.MovementUpdate can only be used for WorldObjects but has been used incorrectly for WowObject (GUID: {wowObject.Guid})");

            if (worldObject.MovementStatus.Transport == null)
                throw new NullReferenceException($"WorldObject (GUID: {worldObject.Guid})" +
                                                 $" was flagged for sending transport data in SMSG_UPDATE_OBJECT but it had no transport reference!");

            writer.WriteBit(worldObject.MovementStatus.Transport.Guid[5]);
            writer.WriteBit(worldObject.MovementStatus.Transport.VehicleRecID.HasValue);
            writer.WriteBit(worldObject.MovementStatus.Transport.Guid[0]);
            writer.WriteBit(worldObject.MovementStatus.Transport.Guid[3]);
            writer.WriteBit(worldObject.MovementStatus.Transport.Guid[6]);
            writer.WriteBit(worldObject.MovementStatus.Transport.Guid[1]);
            writer.WriteBit(worldObject.MovementStatus.Transport.Guid[4]);
            writer.WriteBit(worldObject.MovementStatus.Transport.Guid[2]);
            writer.WriteBit(worldObject.MovementStatus.Transport.PrevMoveTime.HasValue);
            writer.WriteBit(worldObject.MovementStatus.Transport.Guid[7]);
        }

        if (createObjectBits.CombatVictim)
        {
            if (wowObject is not UnitBase unit)
                writer.WriteUInt8(0);
            else
            {
            }
            // @todo
            //ObjectGuid guid = ObjectGuid.Empty;
            //WriteBit(guid[2]);
            //WriteBit(guid[7]);
            //WriteBit(guid[0]);
            //WriteBit(guid[4]);
            //WriteBit(guid[5]);
            //WriteBit(guid[6]);
            //WriteBit(guid[1]);
            //WriteBit(guid[3]);
        }

        if (createObjectBits.AnimKit)
        {
            writer.WriteBit(true); // !hasAIAnimKit
            writer.WriteBit(true); // !hasMovementAnimKit
            writer.WriteBit(true); // !hasMeleeAnimKit
        }

        writer.FlushBits();

        foreach (uint pauseTime in pauseTimes)
        {
            writer.WriteUInt32(pauseTime);
        }

        if (createObjectBits.MovementUpdate)
        {
            if (wowObject is not UnitBase unit)
                throw new Exception($"CreateObjectBits.MovementUpdate can only be used for Units but has been used incorrectly for WowObject (GUID: {wowObject.Guid})");

            writer.WriteByteSeq(unit.Guid[4]);
            writer.WriteFloat(unit.MovementSpeed[MovementType.RunBack]);

            if (unit.MovementStatus.Fall != null)
            {
                if (unit.MovementStatus.Fall.Velocity != null)
                {
                    writer.WriteFloat(unit.MovementStatus.Fall.Velocity.Speed);
                    writer.WriteFloat(unit.MovementStatus.Fall.Velocity.Direction.X);
                    writer.WriteFloat(unit.MovementStatus.Fall.Velocity.Direction.Y);
                }

                writer.WriteUInt32(unit.MovementStatus.Fall.Time);
                writer.WriteFloat(unit.MovementStatus.Fall.JumpVelocity);
            }

            writer.WriteFloat(unit.MovementSpeed[MovementType.SwimBack]);

            // if (hasSplineElevation)
            //     WriteFloat(worldObject.MovementStatus.StepUpStartElevation);

            //  if (hasSpline)
            //      Movement::PacketBuilder::WriteCreateData(*self->movespline, *data);

            writer.WriteFloat(unit.MovementStatus.Position.Z);
            writer.WriteByteSeq(unit.Guid[5]);

            if (unit.MovementStatus.Transport != null)
            {
                writer.WriteByteSeq(unit.MovementStatus.Transport.Guid[5]);
                writer.WriteByteSeq(unit.MovementStatus.Transport.Guid[7]);
                writer.WriteUInt32(unit.MovementStatus.Transport.MoveTime);
                writer.WriteFloat(unit.MovementStatus.Transport.Facing);

                if (unit.MovementStatus.Transport.PrevMoveTime.HasValue)
                    writer.WriteUInt32(unit.MovementStatus.Transport.PrevMoveTime.Value);

                writer.WriteFloat(unit.MovementStatus.Transport.Position.Y);
                writer.WriteFloat(unit.MovementStatus.Transport.Position.X);
                writer.WriteByteSeq(unit.MovementStatus.Transport.Guid[3]);
                writer.WriteFloat(unit.MovementStatus.Transport.Position.Z);
                writer.WriteByteSeq(unit.MovementStatus.Transport.Guid[0]);

                if (unit.MovementStatus.Transport.VehicleRecID.HasValue)
                    writer.WriteInt32(unit.MovementStatus.Transport.VehicleRecID.Value);

                writer.WriteUInt8(unit.MovementStatus.Transport.VehicleSeatIndex);
                writer.WriteByteSeq(unit.MovementStatus.Transport.Guid[1]);
                writer.WriteByteSeq(unit.MovementStatus.Transport.Guid[6]);
                writer.WriteByteSeq(unit.MovementStatus.Transport.Guid[2]);
                writer.WriteByteSeq(unit.MovementStatus.Transport.Guid[4]);
            }

            writer.WriteFloat(unit.MovementStatus.Position.X);
            writer.WriteFloat(unit.MovementSpeed[MovementType.PitchRate]);

            writer.WriteByteSeq(unit.Guid[3]);
            writer.WriteByteSeq(unit.Guid[0]);

            writer.WriteFloat(unit.MovementSpeed[MovementType.Swim]);
            writer.WriteFloat(unit.MovementStatus.Position.Y);

            writer.WriteByteSeq(unit.Guid[7]);
            writer.WriteByteSeq(unit.Guid[1]);
            writer.WriteByteSeq(unit.Guid[2]);

            writer.WriteFloat(unit.MovementSpeed[MovementType.Walk]);

            if (unit.MovementStatus.MoveTime != 0)
                writer.WriteUInt32(unit.MovementStatus.MoveTime);

            writer.WriteFloat(unit.MovementSpeed[MovementType.TurnRate]);

            writer.WriteByteSeq(unit.Guid[6]);

            writer.WriteFloat(unit.MovementSpeed[MovementType.Flight]);

            if (unit.MovementStatus.Facing != 0f)
                writer.WriteFloat(unit.MovementStatus.Facing);

            writer.WriteFloat(unit.MovementSpeed[MovementType.Run]);

            // if (Has pitch)
                //WriteFloat(worldObject.MovementStatus.Pitch);

            writer.WriteFloat(unit.MovementSpeed[MovementType.FlightBack]);
        }

        if (createObjectBits.Vehicle)
        {
            if (wowObject is not UnitBase unit)
                throw new Exception($"CreateObjectBits.Vehicle can only be used for Units but has been used incorrectly for WowObject (GUID: {wowObject.Guid})");

            if (unit.MovementStatus.Transport != null)
                writer.WriteFloat(unit.MovementStatus.Transport.Facing);
            else
                writer.WriteFloat(unit.MovementStatus.Facing);

            writer.WriteUInt32(0); // GetVehicleKit()->GetVehicleInfo()->ID
        }

        if (createObjectBits.MovementTransport)
        {
            if (wowObject is not WorldObject worldObject)
                throw new Exception($"CreateObjectBits.MovementUpdate can only be used for WorldObjects but has been used incorrectly for WowObject (GUID: {wowObject.Guid})");

            if (worldObject.MovementStatus.Transport == null)
                throw new NullReferenceException($"WorldObject (GUID: {worldObject.Guid})" +
                                                 $" was flagged for sending transport data in SMSG_UPDATE_OBJECT but it had no transport reference!");

            writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[0]);
            writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[5]);

            if (worldObject.MovementStatus.Transport.VehicleRecID.HasValue)
                writer.WriteInt32(worldObject.MovementStatus.Transport.VehicleRecID.Value);

            writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[3]);
            writer.WriteFloat(worldObject.MovementStatus.Transport.Position.X);
            writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[4]);
            writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[6]);
            writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[1]);
            writer.WriteUInt32(worldObject.MovementStatus.Transport.MoveTime);
            writer.WriteFloat(worldObject.MovementStatus.Transport.Position.Y);
            writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[2]);
            writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[7]);
            writer.WriteFloat(worldObject.MovementStatus.Transport.Position.Z);
            writer.WriteUInt8(worldObject.MovementStatus.Transport.VehicleSeatIndex);
            writer.WriteFloat(worldObject.MovementStatus.Transport.Facing);

            if (worldObject.MovementStatus.Transport.PrevMoveTime.HasValue)
                writer.WriteUInt32(worldObject.MovementStatus.Transport.PrevMoveTime.Value);
        }

        if (createObjectBits.Rotation)
        {
            //if (worldObject is not GameObject gameObject)
            //    throw new Exception(
            //        $"WorldObject (GUID: {worldObject.Guid}) has CreateObjectBits.Rotation but is not a gameObject!");
            //WriteInt64(gameObject.PackedLocalRotation);
        }

        if (createObjectBits.AreaTrigger)
        {
            // Unused by the client (wasn't ready in 4.3.4)
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteUInt8(0);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
            writer.WriteFloat(0f);
        }

        if (createObjectBits.Stationary)
        {
            //@todo
            //writer.WriteFloat(worldObject.MovementStatus.Facing);
            //writer.WriteFloat(worldObject.MovementStatus.Position.X);
            //writer.WriteFloat(worldObject.MovementStatus.Position.Y);
            //writer.WriteFloat(worldObject.MovementStatus.Position.Z);
        }

        if (createObjectBits.CombatVictim)
        {
            // @todo
            //ObjectGuid guid = ObjectGuid.Empty;
            //WriteByteSeq(guid[4]);
            //WriteByteSeq(guid[0]);
            //WriteByteSeq(guid[3]);
            //WriteByteSeq(guid[5]);
            //WriteByteSeq(guid[7]);
            //WriteByteSeq(guid[6]);
            //WriteByteSeq(guid[2]);
            //WriteByteSeq(guid[1]);
        }

        if (createObjectBits.AnimKit)
        {
            // @todo
            // if (hasAIAnimKit)
            //    WriteUInt16(self->GetAIAnimKitId());

            //if (hasMovementAnimKit)
            //    WriteUInt16(self->GetMovementAnimKitId());

            //if (hasMeleeAnimKit)
            //    WriteUInt16(self->GetMeleeAnimKitId());
        }

        if (createObjectBits.ServerTime)
            writer.WriteUInt32(0); // GameTime::GetGameTimeMS() @todo
    }

    private void WriteUpdateFields(ref ServerPacketWriter writer, WowObject objectToCreate, DataFieldVisibilityFlags visibilityFlags)
    {
        Span<uint> updateBlockBits = stackalloc uint[objectToCreate.UpdateFieldBlockCount];
        Span<byte> updateData = stackalloc byte[objectToCreate.UpdateFieldCount * MirroredObject.UpdateFieldSize];
        updateBlockBits.Clear();

        // Determine update fields which have been marked as dirty
        int dataPosition = 0;
        for (int i = 0; i < objectToCreate.UpdateFieldCount; ++i)
        {
            if (!objectToCreate.IsUpdateFieldDirty(i) || !objectToCreate.IsUpdateFieldVisible(i, visibilityFlags))
                continue;

            int blockIndex = i / MirroredObject.FieldsPerBlock;
            updateBlockBits[blockIndex] |= 1u << i % MirroredObject.FieldsPerBlock;

            objectToCreate.UpdateFieldData(i).CopyTo(updateData.Slice(dataPosition, MirroredObject.UpdateFieldSize));
            dataPosition += MirroredObject.UpdateFieldSize;
        }

        // Write the dirty field bit blocks
        writer.WriteUInt8((byte)updateBlockBits.Length);
        foreach (uint blockBits in updateBlockBits)
            writer.WriteUInt32(blockBits);

        // Append the field data
        writer.WriteBytes(updateData.Slice(0, dataPosition));
    }
}
