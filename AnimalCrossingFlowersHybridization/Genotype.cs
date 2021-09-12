using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization
{
    public class Genotype
    {
        public Genotype(IEnumerable<Locus> locus)
        {
            Locus = locus.OrderBy(t => t.Gene).ToArray();
        }

        public IEnumerable<Locus> Locus { get; }
    }
}