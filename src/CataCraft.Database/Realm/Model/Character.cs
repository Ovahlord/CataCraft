// This file is part of the CataCraft project, which is published under the MIT license.

using System.ComponentModel.DataAnnotations;

namespace CataCraft.Database.Realm.Model;

public class Character
{
    public int Id { get; set; }

    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    public byte RaceId { get; set; }

    public byte ClassId { get; set; }

    public byte SexId { get; set; }

    public byte SkinId { get; set; }

    public byte FaceId { get; set; }

    public byte HairStyleId { get; set; }

    public byte HairColorId { get; set; }

    public byte FacialHairStyleId { get; set; }

    public byte OutfitId { get; set; }

    public DateTime CreationTime { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public CharacterData? CharacterData { get; set; }
    public CharacterStats? Stats { get; set; }
    public RealmCharacter? RealmCharacter { get; set; }
}
