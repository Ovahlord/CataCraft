// This file is part of the CataCraft project, which is published under the MIT license.

using System.Collections.Concurrent;
using CataCraft.DBC;
using CataCraft.DBC.Model;
using CataCraft.Game.Game.Realm.World.Map;

namespace CataCraft.Game.Game.Realm.World;

public class World
{
    private readonly Realm _realm;
    private readonly ConcurrentDictionary<int, MapInstance> _instances = [];

    public World(Realm realm)
    {
        _realm = realm;
    }

    public async ValueTask<MapInstance?> GetInstanceForMapIdAsync(int mapId)
    {
        if (_instances.TryGetValue(mapId, out MapInstance? instance))
            return instance;

        if (!DBCManager.SMapStore.TryGetValue(mapId, out MapEntry? mapEntry))
            return null;

        instance = new MapInstance(mapEntry);
        if (!_instances.TryAdd(mapId, instance))
            return null;

        await instance.LoadDataAsync();
        return instance;
    }
}
