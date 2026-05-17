// This file is part of the CataCraft project, which is published under the MIT license.

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Login.Model;

[PrimaryKey(nameof(GameAccountId))]
public class GameAccountBan
{
    public long GameAccountId { get; set; }

    public DateTime BanTime { get; set; } = DateTime.UtcNow;

    [MaxLength(100)]
    public string BanReason { get; set; } = string.Empty;

    private GameAccount GameAccount { get; set; } = null!;
}
