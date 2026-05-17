// This file is part of the CataCraft project, which is published under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Game.Model;

[PrimaryKey(nameof(RaceId), nameof(ClassId))]
public class CharacterCreationLocation
{
    public byte RaceId { get; set; }
    public byte ClassId { get; set; }
    public int MapId { get; set; }
    public float PositionX { get; set; }
    public float PositionY { get; set; }
    public float PositionZ { get; set; }
    public float Facing { get; set; }
}
