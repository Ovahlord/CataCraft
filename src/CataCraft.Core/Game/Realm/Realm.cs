// This file is part of the CataCraft project, which is published under the MIT license.

using System.Net;
using System.Net.Sockets;
using System.Threading.Channels;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Networking;
using CataCraft.Core.Server.Protocol.Packets.GamePackets;
using CataCraft.Database.Login;
using CataCraft.Database.Realm;
using CataCraft.Database.Realm.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Core.Game.Realm;

/// <summary>
/// The primary entry point to the world. It manages social features and controls the creation and management of
/// world instances to which a player can connect
/// </summary>
public class Realm
{
    // Public properties
    public byte RealmId { get; private set; }
    public string RealmName { get; private set; }
    public RealmType Type { get; private set; }
    public IPEndPoint SecureIpEndpoint { get; private set; }
    public IPEndPoint EntryIpEndpoint { get; private set; }
    public byte RealmCategory { get; private set; }
    public bool LockedForNewPlayers { get; private set; }
    public bool RecommendedForNewPlayers { get; private set; }
    public bool IsFull { get; private set; }
    public int AllowedBuild { get; private set; }
    public bool Online { get;  private set; }
    public float Population { get; private set; }
    public World.World World { get; private set; }

    // Internal fields
    private readonly TcpListener _entryConnectionListener;
    private readonly TcpListener _securedConnectionListener;
    private CancellationTokenSource _cts = new();

    public Realm(Database.Realm.Model.Realm realmDbEntry)
    {
        EntryIpEndpoint = IPEndPoint.Parse(realmDbEntry.EntryIpEndpoint);
        SecureIpEndpoint = IPEndPoint.Parse(realmDbEntry.SecureIpEndpoint);
        _entryConnectionListener = new(EntryIpEndpoint);
        _securedConnectionListener = new(SecureIpEndpoint);
        RealmId = realmDbEntry.Id;
        RealmName = realmDbEntry.RealmName;
        Type = (RealmType)realmDbEntry.RealmType;
        RealmCategory = realmDbEntry.RealmCategory;
        LockedForNewPlayers = realmDbEntry.LockedForNewPlayers;
        RecommendedForNewPlayers = realmDbEntry.RecommendedForNewPlayers;
        AllowedBuild = realmDbEntry.AllowedBuild;

        World = new(this);
    }

    public void Open()
    {
        if (Online)
            return;

        _cts = new();
        _ = ListenForConnectionsAsync(_entryConnectionListener, _cts.Token);
        _ = ListenForConnectionsAsync(_securedConnectionListener, _cts.Token);

        Online = true;
        Console.WriteLine($"Realm {RealmName} is now open");
    }

    public void Close()
    {
        if (!Online)
            return;

        _cts.Cancel();
        _cts.Dispose();

        Console.WriteLine($"Realm {RealmName} is now closed");
    }

    private async Task ListenForConnectionsAsync(TcpListener tcpListener, CancellationToken cancellationToken = default)
    {
        tcpListener.Start();

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync(cancellationToken);
                Console.WriteLine($"GAME SESSION === Client connected: {client.Client.RemoteEndPoint}");
                GameSession session = new(client, this);

                // Enqueue the first connection initializer packet
                ServerConnectionInitialize connectionInitialize = new();
                session.EnqueuePacket(ref connectionInitialize);
            }
        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            tcpListener.Stop();
        }
    }
}
