// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Game.World;

public sealed class World
{
    public Game.Realm.Realm Realm { get; private set; }

    public World(Game.Realm.Realm realm)
    {
        Realm = realm;
    }
}
