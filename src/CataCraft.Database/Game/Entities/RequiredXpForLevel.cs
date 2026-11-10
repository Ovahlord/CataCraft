// This file is part of the CataCraft project, which is published under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Game.Entities;

[PrimaryKey(nameof(Level))]
public class RequiredXpForLevel
{
    public byte Level { get; set; }
    public int RequiredXp { get; set; }
}
