// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Game.Entities.Object;

/// <summary>
/// An interface to allow accessing transport information across multiple entity types for building UpdateObject packets
/// </summary>
public interface ITransportInfo
{
    MovementTransport? Transport { get; }
}
