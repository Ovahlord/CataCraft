// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Enums;

[Flags]
public enum FactionFlags
{
    None            = 0x00, // no faction flag
    Visible         = 0x01, // makes visible in client (set or can be set at interaction with target of this faction)
    AtWar           = 0x02, // enable AtWar-button in client. player controlled (except opposition team always war state), Flag only set on initial creation
    Hidden          = 0x04, // hidden faction from reputation pane in client (player can gain reputation, but this update not sent to client)
    InvisibleForced = 0x08, // always overwrite FACTION_FLAG_VISIBLE and hide faction in rep.list, used for hide opposite team factions
    PeaceForced     = 0x10, // always overwrite FACTION_FLAG_AT_WAR, used for prevent war with own team factions
    Inactive        = 0x20, // player controlled, state stored in characters.data (CMSG_SET_FACTION_INACTIVE)
    Rival           = 0x40, // flag for the two competing outland factions
    Special         = 0x80 // horde and alliance home cities and their northrend allies have this flag
}
