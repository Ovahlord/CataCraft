// This file is part of the CataCraft project, which is published under the MIT license.

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using CataCraft.Core.Configuration;
using CataCraft.DBC.Model;
using CataCraft.Game.Entities.Object;
using CataCraft.Game.Entities.Player;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Protocol.Packets.GamePackets;

namespace CataCraft.Game.World.Map;

public class MapInstance
{
    private const float DefaultUpdateTickRate = 2.5f;
    private const float DefaultHeartbeatRate = 0.2f;

    private readonly CancellationTokenSource _cts = new();
    private readonly MapEntry _mapEntry;
    private readonly float _updateTickRate;
    private readonly float _heartbeatRate;

    private readonly ConcurrentDictionary<WowGuid, WowObject> _wowObjects = [];
    private readonly ConcurrentDictionary<WowGuid, Player> _playerObjects = [];

    public MapInstance(MapEntry mapEntry)
    {
        _mapEntry = mapEntry;

        if (AppSettings.TryGetConfigValue("MapSettings", "UpdateTickRate", out float tickRate) && tickRate > 0f)
            _updateTickRate = tickRate;
        else
            _updateTickRate = DefaultUpdateTickRate;

        if (AppSettings.TryGetConfigValue("MapSettings", "UpdateTickRate", out float heartbeatRate) && heartbeatRate > 0f)
            _heartbeatRate = heartbeatRate;
        else
            _heartbeatRate = DefaultHeartbeatRate;

        _ = UpdateAsync(_cts.Token);
    }

    public async Task LoadDataAsync()
    {
    }

    public bool TryGetPlayer(WowGuid playerGuid, [NotNullWhen(true)] out Player? player)
    {
        return _playerObjects.TryGetValue(playerGuid, out player);
    }

    public bool AddWowObject(WowObject wowObject)
    {
        if (!_wowObjects.TryAdd(wowObject.Guid, wowObject))
            return false;

        if (wowObject is Player player)
            return _playerObjects.TryAdd(wowObject.Guid, player);

        return true;
    }

    public void RemoveWowObject(WowObject wowObject)
    {
        _wowObjects.TryRemove(wowObject.Guid, out _);

        if (wowObject is Player)
            _playerObjects.TryRemove(wowObject.Guid, out _);
    }

    private async Task UpdateAsync(CancellationToken token = default)
    {
        Task heartbeatTask = Task.Delay((int)(1000 / _heartbeatRate), token);

        while (!token.IsCancellationRequested)
        {
            await Task.Delay((int)(1000 / _updateTickRate), token);

            // Perform all actions which should occur only once per heartbeat
            if (heartbeatTask.IsCompleted)
            {
                heartbeatTask = Task.Delay((int)(1000 / _heartbeatRate), token);
            }

            UpdateObjects();
        }
    }

    private void UpdateObjects()
    {
        foreach (Player player in _playerObjects.Values)
        {
            if (player.Session == null || player.MapInstance != this)
                continue;

            // There is nothing to update right now
            if (player.NewObjects.Count == 0 && player.VisibleObjects.Count == 0 && player.OutOfRangeObjects.Count == 0)
                continue;

            ServerUpdateObject updateObject = new()
            {
                MapRecId = (ushort)_mapEntry.ID
            };

            // Building create object packet segments for everything that just became visible
            foreach (WowObject wowObject in player.NewObjects)
            {
                DataFieldVisibilityFlags visibilityFlags = DataFieldVisibilityFlags.Public;
                CreateObjectBits createObjectBits = new();

                // Player is being created for the first time
                if (wowObject == player)
                {
                    visibilityFlags |= DataFieldVisibilityFlags.Private | DataFieldVisibilityFlags.UnitAll | DataFieldVisibilityFlags.Dynamic;
                    createObjectBits.ThisIsYou = true;
                }

                if (wowObject.Guid.IsPlayer || wowObject.Guid.IsUnit || wowObject.Guid.IsPet)
                    createObjectBits.MovementUpdate = true;

                updateObject.AddObjectToCreate(player, visibilityFlags, createObjectBits);
            }

            // Building value update object packet segments for everything that has its data changed
            foreach (WowObject wowObject in player.VisibleObjects)
            {
                DataFieldVisibilityFlags visibilityFlags = DataFieldVisibilityFlags.Public;
                if (wowObject.DataFields.HasPendingUpdates(visibilityFlags))
                    updateObject.AddObjectToUpdate(wowObject, visibilityFlags);
            }

            // Building out of range update object packet segments for everything that has moved out of visibility range
            foreach (WowObject wowObject in player.OutOfRangeObjects)
            {
                updateObject.AddOutOfRangeObject(wowObject);
            }

            // Serialize packet and enqueue data
            if (updateObject.HasObjectsToUpdate)
                player.Session.EnqueuePacket(ref updateObject);

            // Now that we have updated everything, we can update the reference holding lists
            player.VisibleObjects.AddRange(player.NewObjects);
            player.NewObjects.Clear();
            player.OutOfRangeObjects.Clear();
        }

        // Clear the change mask of all wow objects since they all have been updated now
        foreach (WowObject wowObject in _wowObjects.Values)
        {
            wowObject.DataFields.ClearChangeMask();
        }
    }
}
