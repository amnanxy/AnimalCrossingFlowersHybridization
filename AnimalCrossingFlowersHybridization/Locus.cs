using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization
{
    public class Locus
    {
        public Locus(Gene gene, IEnumerable<char> traits)
        {
            Gene = gene;
            Traits = traits.OrderBy(t => t).ToArray();
        }

        public Gene Gene { get; }

        public IEnumerable<char> Traits { get; }
    }
}