using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization
{
    public class Genotype : ValueObject
    {
        public Genotype(IEnumerable<Locus> locus)
        {
            Locus = locus.OrderBy(t => t.Gene).ToArray();
        }

        public IEnumerable<Locus> Locus { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return Locus;
        }
    }
}