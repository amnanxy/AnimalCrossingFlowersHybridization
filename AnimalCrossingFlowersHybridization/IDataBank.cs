using System.Collections.Generic;

namespace AnimalCrossingFlowersHybridization;

public interface IDataBank
{
    IReadOnlyList<Flower> All { get; }

    IReadOnlyList<Flower> Seeds { get; }

    Color RareColor { get; }
}