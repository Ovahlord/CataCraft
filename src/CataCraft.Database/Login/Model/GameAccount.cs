// This file is part of the CataCraft project, which is published under the MIT license.

using System.ComponentModel.DataAnnotations;

namespace CataCraft.Database.Login.Model;

public class GameAccount
{
    public long Id { get; set; }

    [MaxLength(16)]
    public string AccountName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    public byte ExpansionLevel { get; set; } = 3;

    public byte ActiveExpansionLevel { get; set; } = 3;

    public byte[] Salt { get; set; } = [];

    public byte[] Verifier { get; set; } = [];

    // Navigation properties
    public GameAccountBan? Ban { get; set; }
    public GameAccountSessionData? SessionData { get; set; }
    public GameAccountSuspension? Suspension { get; set; }
    public List<GameAccountData>? AccountData { get; set; }
    public GameAccountTutorial? Tutorial { get; set; }
}
