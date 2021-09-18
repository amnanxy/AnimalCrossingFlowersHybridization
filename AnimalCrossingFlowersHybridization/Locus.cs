using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization
{
    public class Locus : ValueObject
    {
        public Locus(Gene gene, IEnumerable<char> traits)
        {
            Gene = gene;
            Traits = traits.OrderBy(t => t).ToArray();
        }

        public Gene Gene { get; }

        public IEnumerable<char> Traits { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Gene;
            
            foreach (var trait in Traits)
            {
                yield return trait;
            }
        }
    }
}