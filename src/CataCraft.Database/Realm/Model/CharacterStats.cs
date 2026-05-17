// This file is part of the CataCraft project, which is published under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Realm.Model;

[PrimaryKey(nameof(CharacterId))]
public class CharacterStats
{
    public int CharacterId { get; set; }

    public byte ExperienceLevel { get; set; } = 1;

    public int Experience { get; set; }

    public ulong Coinage { get; set; }

    public int CharacterFlags { get; set; }

    public int CharacterFlags2 { get; set; }

    public bool FirstLogin { get; set; } = true;

    public int MapId { get; set; }

    public int AreaId { get; set; }

    public float PositionX { get; set; }

    public float PositionY { get; set; }

    public float PositionZ { get; set; }

    public float Orientation { get; set; }

    // Navigation properties
    public Character Character { get; set; } = null!;
}
