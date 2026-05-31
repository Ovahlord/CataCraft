// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Game.Entities.Object;
using CataCraft.Core.Game.Entities.Unit;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerUpdateObject : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_UPDATE_OBJECT;

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
    public List<WowObject> ObjectsOutOfRange { get; set; } = [];
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

    public void AddObjectToCreate(WowObject objectToCreate, bool newSpawn,  DataFieldVisibilityFlags visibilityFlags, CreateObjectBits createObjectBits)
    {
        _objectsToCreate.Add(new ObjectToCreate()
        {
            Object = objectToCreate,
            CreateObjectBits = createObjectBits,
            NewSpawn = newSpawn,
            VisibilityFlags = visibilityFlags
        });
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteUInt16(MapRecId);
        writer.WriteInt32(_objectsToCreate.Count + _objectsToUpdate.Count + ObjectsOutOfRange.Count);

        if (ObjectsOutOfRange.Count != 0)
        {
            writer.WriteUInt8((byte)ObjectUpdateType.OutOfRangeObjects);
            writer.WriteUInt32((uint)ObjectsOutOfRange.Count);

            foreach (WowObject objectOutOfRange in ObjectsOutOfRange)
                writer.WritePackGUID(objectOutOfRange.Guid);
        }

        foreach (ObjectToCreate objectToCreate in _objectsToCreate)
        {
            writer.WriteUInt8((byte)(objectToCreate.NewSpawn ? ObjectUpdateType.CreateObject2 : ObjectUpdateType.CreateObject));
            writer.WritePackGUID(objectToCreate.Object.Guid);
            writer.WriteUInt8((byte)objectToCreate.Object.Guid.ObjectType);

            WriteCreateObjectBlock(ref writer, objectToCreate.Object, objectToCreate.CreateObjectBits);
            WriteFullDataFields(ref writer, objectToCreate.Object, objectToCreate.VisibilityFlags);
        }

        foreach (ObjectToUpdate objectToUpdate in _objectsToUpdate)
        {
            writer.WriteUInt8((byte)ObjectUpdateType.Values);
            writer.WritePackGUID(objectToUpdate.Object.Guid);
            writer.WriteUInt8((byte)objectToUpdate.Object.Guid.ObjectType);

            //WriteUpdatedDataFields(objectToUpdate.Object, objectToUpdate.VisibilityFlags);
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }

    private void WriteCreateObjectBlock(ref ServerPacketWriter writer, WowObject worldObject, CreateObjectBits createObjectBits)
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
            writer.WriteBit(worldObject.MovementStatus.MovementFlags0 == MovementFlags0.None);
            writer.WriteBit(worldObject.MovementStatus.Facing == 0f);
            writer.WriteBit(worldObject.Guid[7]);
            writer.WriteBit(worldObject.Guid[3]);
            writer.WriteBit(worldObject.Guid[2]);

            if (worldObject.MovementStatus.MovementFlags0 != MovementFlags0.None)
                writer.WriteBits((uint)worldObject.MovementStatus.MovementFlags0, 30);

            writer.WriteBit(false); // hasSpline && !self->IsPlayer() - !Has player spline data
            writer.WriteBit(true); // !Has pitch
            writer.WriteBit(false); // Has spline data (independent)
            writer.WriteBit(worldObject.MovementStatus.Fall != null);
            writer.WriteBit(true); // !Has spline elevation
            writer.WriteBit(worldObject.Guid[5]);
            writer.WriteBit(worldObject.MovementStatus.Transport != null);
            writer.WriteBit(worldObject.MovementStatus.MoveTime == 0);

            if (worldObject.MovementStatus.Transport != null)
            {
                writer.WriteBit(worldObject.MovementStatus.Transport.Guid[1]);
                writer.WriteBit(worldObject.MovementStatus.Transport.PrevMoveTime.HasValue);
                writer.WriteBit(worldObject.MovementStatus.Transport.Guid[4]);
                writer.WriteBit(worldObject.MovementStatus.Transport.Guid[0]);
                writer.WriteBit(worldObject.MovementStatus.Transport.Guid[6]);
                writer.WriteBit(worldObject.MovementStatus.Transport.VehicleRecID.HasValue);
                writer.WriteBit(worldObject.MovementStatus.Transport.Guid[7]);
                writer.WriteBit(worldObject.MovementStatus.Transport.Guid[5]);
                writer.WriteBit(worldObject.MovementStatus.Transport.Guid[3]);
                writer.WriteBit(worldObject.MovementStatus.Transport.Guid[2]);
            }

            writer.WriteBit(worldObject.Guid[4]);

            //if (hasSpline)
            //    Movement::PacketBuilder::WriteCreateBits(*self->movespline, *data);

            writer.WriteBit(worldObject.Guid[6]);

            if (worldObject.MovementStatus.Fall != null)
                writer.WriteBit(worldObject.MovementStatus.Fall.Velocity != null);

            writer.WriteBit(worldObject.Guid[0]);
            writer.WriteBit(worldObject.Guid[1]);
            writer.WriteBit(worldObject.MovementStatus.HeightChangeFailed);
            writer.WriteBit(worldObject.MovementStatus.MovementFlags1 == MovementFlags1.None);

            if (worldObject.MovementStatus.MovementFlags1 != MovementFlags1.None)
                writer.WriteBits((uint)worldObject.MovementStatus.MovementFlags1, 12);
        }

        if (createObjectBits.MovementTransport)
        {
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
            if (worldObject is not Unit unit)
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
            if (worldObject is not Unit unit)
                throw new Exception($"CreateObjectBits.MovementUpdate can only be used for Units but has been used incorrectly for WorldObject (GUID: {worldObject.Guid})");

            writer.WriteByteSeq(worldObject.Guid[4]);
            writer.WriteFloat(unit.MovementSpeed[MovementType.RunBack]);

            if (worldObject.MovementStatus.Fall != null)
            {
                if (worldObject.MovementStatus.Fall.Velocity != null)
                {
                    writer.WriteFloat(worldObject.MovementStatus.Fall.Velocity.Speed);
                    writer.WriteFloat(worldObject.MovementStatus.Fall.Velocity.Direction.X);
                    writer.WriteFloat(worldObject.MovementStatus.Fall.Velocity.Direction.Y);
                }

                writer.WriteUInt32(worldObject.MovementStatus.Fall.Time);
                writer.WriteFloat(worldObject.MovementStatus.Fall.JumpVelocity);
            }

            writer.WriteFloat(unit.MovementSpeed[MovementType.SwimBack]);

            // if (hasSplineElevation)
            //     WriteFloat(worldObject.MovementStatus.StepUpStartElevation);

            //  if (hasSpline)
            //      Movement::PacketBuilder::WriteCreateData(*self->movespline, *data);

            writer.WriteFloat(worldObject.MovementStatus.Position.Z);
            writer.WriteByteSeq(worldObject.Guid[5]);

            if (worldObject.MovementStatus.Transport != null)
            {
                writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[5]);
                writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[7]);
                writer.WriteUInt32(worldObject.MovementStatus.Transport.MoveTime);
                writer.WriteFloat(worldObject.MovementStatus.Transport.Facing);

                if (worldObject.MovementStatus.Transport.PrevMoveTime.HasValue)
                    writer.WriteUInt32(worldObject.MovementStatus.Transport.PrevMoveTime.Value);

                writer.WriteFloat(worldObject.MovementStatus.Transport.Position.Y);
                writer.WriteFloat(worldObject.MovementStatus.Transport.Position.X);
                writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[3]);
                writer.WriteFloat(worldObject.MovementStatus.Transport.Position.Z);
                writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[0]);

                if (worldObject.MovementStatus.Transport.VehicleRecID.HasValue)
                    writer.WriteInt32(worldObject.MovementStatus.Transport.VehicleRecID.Value);

                writer.WriteUInt8(worldObject.MovementStatus.Transport.VehicleSeatIndex);
                writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[1]);
                writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[6]);
                writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[2]);
                writer.WriteByteSeq(worldObject.MovementStatus.Transport.Guid[4]);
            }

            writer.WriteFloat(worldObject.MovementStatus.Position.X);
            writer.WriteFloat(unit.MovementSpeed[MovementType.PitchRate]);

            writer.WriteByteSeq(worldObject.Guid[3]);
            writer.WriteByteSeq(worldObject.Guid[0]);

            writer.WriteFloat(unit.MovementSpeed[MovementType.Swim]);
            writer.WriteFloat(worldObject.MovementStatus.Position.Y);

            writer.WriteByteSeq(worldObject.Guid[7]);
            writer.WriteByteSeq(worldObject.Guid[1]);
            writer.WriteByteSeq(worldObject.Guid[2]);

            writer.WriteFloat(unit.MovementSpeed[MovementType.Walk]);

            if (worldObject.MovementStatus.MoveTime != 0)
                writer.WriteUInt32(worldObject.MovementStatus.MoveTime);

            writer.WriteFloat(unit.MovementSpeed[MovementType.TurnRate]);

            writer.WriteByteSeq(worldObject.Guid[6]);

            writer.WriteFloat(unit.MovementSpeed[MovementType.Flight]);

            if (worldObject.MovementStatus.Facing != 0f)
                writer.WriteFloat(worldObject.MovementStatus.Facing);

            writer.WriteFloat(unit.MovementSpeed[MovementType.Run]);

            // if (Has pitch)
                //WriteFloat(worldObject.MovementStatus.Pitch);

            writer.WriteFloat(unit.MovementSpeed[MovementType.FlightBack]);
        }

        if (createObjectBits.Vehicle)
        {
            if (worldObject.MovementStatus.Transport != null)
                writer.WriteFloat(worldObject.MovementStatus.Transport.Facing);
            else
                writer.WriteFloat(worldObject.MovementStatus.Facing);

            writer.WriteUInt32(0); // GetVehicleKit()->GetVehicleInfo()->ID
        }

        if (createObjectBits.MovementTransport)
        {
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
            writer.WriteFloat(worldObject.MovementStatus.Facing);
            writer.WriteFloat(worldObject.MovementStatus.Position.X);
            writer.WriteFloat(worldObject.MovementStatus.Position.Y);
            writer.WriteFloat(worldObject.MovementStatus.Position.Z);
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

    private void WriteFullDataFields(ref ServerPacketWriter writer, WowObject objectToCreate, DataFieldVisibilityFlags visibilityFlags)
    {
        Span<uint> updateBlockBits = stackalloc uint[objectToCreate.DataFields.UpdateFieldBlockCount];
        updateBlockBits.Clear();

        // Determine all the fields that we want to send
        for (int i = 0; i < objectToCreate.DataFields.Count; ++i)
        {
            if (!objectToCreate.DataFields.IsVisible(i, visibilityFlags) || !objectToCreate.DataFields.HasBeenModified(i))
                continue;

            int blockIndex = i / 32;
            updateBlockBits[blockIndex] |= 1u << i % 32;
        }

        // Though the client supports trimming trailing zero values, retail does send them so we will do so as well
        writer.WriteUInt8((byte)updateBlockBits.Length);
        foreach (uint blockBits in updateBlockBits)
            writer.WriteUInt32(blockBits);

        // Append all data fields that have been flagged as visible
        int currentBlockIndex = 0;
        foreach (uint blockBits in updateBlockBits)
        {
            if (blockBits == 0)
            {
                ++currentBlockIndex;
                continue;
            }

            for (int i = 0; i < 32; ++i)
            {
                if ((updateBlockBits[currentBlockIndex] & (1 << i)) != 0)
                {
                    int fieldOffset = (currentBlockIndex * 32 + i) * sizeof(uint);
                    ReadOnlySpan<byte> fieldData = objectToCreate.DataFields.Data.Slice(fieldOffset, sizeof(uint));
                    writer.WriteBytes(fieldData);
                }
            }

            ++currentBlockIndex;
        }
    }
}
