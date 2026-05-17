// This file is part of the CataCraft project, which is published under the MIT license.

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Login.Model;

[PrimaryKey(nameof(GameAccountId))]
public class GameAccountSessionData
{
    public long GameAccountId { get; set; }

    public byte[] SessionKey { get; set; } = [];

    public byte ClientLocale { get; set; }

    // Navigation property
    public GameAccount GameAccount { get; set; } = null!;
}
