// This file is part of the CataCraft project, which is published under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Login.Model;

[PrimaryKey(nameof(GameAccountId))]
public class GameAccountTutorial
{
    public long GameAccountId { get; set; }
    public uint[] TutorialBits { get; set; } = null!;

    // Navigation Property
    public GameAccount GameAccount { get; set; } = null!;
}
