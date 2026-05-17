// This file is part of the CataCraft project, which is published under the MIT license.

using System.ComponentModel.DataAnnotations;

namespace CataCraft.Database.Realm.Model;

public class Realm
{
    public byte Id { get; set; }

    [MaxLength(100)]
    public string RealmName { get; set; } = string.Empty;

    public int RealmType { get; set; }

    public byte RealmCategory { get; set; } = 1;

    public bool RecommendedForNewPlayers { get; set; }

    public bool LockedForNewPlayers { get; set; }

    public int MaxPlayers { get; set; } = 1000;

    public int AllowedBuild { get; set; } = 15595;

    [MaxLength(20)]
    public string EntryIpEndpoint { get; set; } = "127.0.0.1:8086";

    [MaxLength(20)]
    public string SecureIpEndpoint { get; set; } = "127.0.0.1:8087";

    // Navigation properties
    private ICollection<RealmCharacter> RealmCharacters = new List<RealmCharacter>();
}
