using System.Collections.Generic;

namespace AnimalCrossingFlowersHybridization
{
    public class Locus
    {
        public Gene Gene { get; init; }

        public IEnumerable<int> Traits { get; init; }
    }
}