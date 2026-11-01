// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Game.Entities.Object;
using CataCraft.Game.Entities.Object.AreaTrigger;
using CataCraft.Game.Entities.Object.DynamicObject;
using CataCraft.Game.Entities.Object.GameObject;
using CataCraft.Game.Entities.Object.Item;
using CataCraft.Game.Entities.Object.Item.Container;
using CataCraft.Game.Entities.Object.Unit;
using CataCraft.Game.Entities.Object.Unit.Player;
using CataCraft.Game.Enums;
using CataCraft.Game.World.Map;

namespace CataCraft.Game.Entities;

/// <summary>
/// The primary factory to produce all kinds of entities form the game
/// </summary>
public static class EntityFactory
{
    private static int s_itemIdCounter;
    private static int s_containerIdCounter;

    public static async Task InitializeEntityIdsAsync()
    {
    }

    /// <summary>
    /// Creates a new instance of a player with a globally valid guid
    /// </summary>
    /// <param name="playerId">The id of the player character which has been generated on character creation</param>
    /// <returns>A new player instance initialized for the player id</returns>
    public static Player CreatePlayer(int playerId)
    {
        WowGuid guid = new(WowGuidType.Player, (uint)playerId);
        return new Player(guid);
    }

    public static Unit CreateUnit(int creatureId, MapInstance mapInstance)
    {
        WowGuid guid = new(WowGuidType.Unit, (uint)creatureId, (uint)mapInstance.GetNextEntityId(WowGuidType.Unit));
        return new Unit(guid);
    }

    public static GameObject CreateGameObject(int gameObjectId, MapInstance mapInstance)
    {
        WowGuid guid = new(WowGuidType.GameObject, (uint)gameObjectId, (uint)mapInstance.GetNextEntityId(WowGuidType.GameObject));
        return new GameObject(guid);
    }

    public static DynamicObject CreateDynamicObject(int dynamicObjectId, MapInstance mapInstance)
    {
        WowGuid guid = new(WowGuidType.DynamicObject, (uint)dynamicObjectId, (uint)mapInstance.GetNextEntityId(WowGuidType.DynamicObject));
        return new DynamicObject(guid);
    }

    public static AreaTrigger CreateAreaTrigger(int areaTriggerId, MapInstance mapInstance)
    {
        WowGuid guid = new(WowGuidType.AreaTrigger, (uint)areaTriggerId, (uint)mapInstance.GetNextEntityId(WowGuidType.AreaTrigger));
        return new AreaTrigger(guid);
    }

    public static Item CreateItem()
    {
        WowGuid guid = new(WowGuidType.Item, (uint)s_itemIdCounter);
        Interlocked.Increment(ref s_itemIdCounter);
        return new Item(guid);
    }

    public static Item CreateItem(int itemId)
    {
        WowGuid guid = new(WowGuidType.Item, (uint)itemId);
        Interlocked.Increment(ref s_itemIdCounter);
        return new Item(guid);
    }

    public static Container CreateContainer()
    {
        WowGuid guid = new(WowGuidType.Container, (uint)s_containerIdCounter);
        Interlocked.Increment(ref s_containerIdCounter);
        return new Container(guid);
    }

    public static Container CreateContainer(int containerId)
    {
        WowGuid guid = new(WowGuidType.Container, (uint)containerId);
        Interlocked.Increment(ref s_containerIdCounter);
        return new Container(guid);
    }
}
