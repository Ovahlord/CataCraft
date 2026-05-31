// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Game.Entities.Object;

public struct CreateObjectBits
{
    public bool PlayHoverAnim { get; set; }
    public bool SupressedGreetings { get; set; }
    public bool Rotation { get; set; }
    public bool AnimKit { get; set; }
    public bool CombatVictim { get; set; }
    public bool ThisIsYou { get; set; }
    public bool Vehicle { get; set; }
    public bool MovementUpdate { get; set; }
    public bool NoBirthAnim { get; set; }
    public bool MovementTransport { get; set; }
    public bool Stationary { get; set; }
    public bool AreaTrigger { get; set; }
    public bool EnablePortals { get; set; }
    public bool ServerTime { get; set; }
}
