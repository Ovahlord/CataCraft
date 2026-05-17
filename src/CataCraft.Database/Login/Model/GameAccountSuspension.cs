// This file is part of the CataCraft project, which is published under the MIT license.

using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Login.Model;

[PrimaryKey(nameof(GameAccountId))]
public class GameAccountSuspension
{
    public long GameAccountId { get; set; }

    public DateTime SuspensionTime { get; set; }

    public DateTime SuspensionExpirationTime { get; set; }
    [MaxLength(100)]
    public string SuspensionReason { get; set; } = string.Empty;

    private GameAccount GameAccount { get; set; } = null!;
}
