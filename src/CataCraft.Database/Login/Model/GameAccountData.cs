// This file is part of the CataCraft project, which is published under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Login.Model;

[PrimaryKey(nameof(GameAccountId), nameof(Id))]
public class GameAccountData
{
    public long GameAccountId { get; set; }
    public int Id  { get; set; }
    public DateTimeOffset Time { get; set; }
    public byte[] Data { get; set; } = [];

    // Navigation Property
    public GameAccount GameAccount { get; set; } = null!;
}
