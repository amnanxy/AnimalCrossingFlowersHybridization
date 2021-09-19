using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization
{
    public class Locus : ValueObject
    {
        private static readonly Dictionary<char, Gene> GeneMapping = new()
        {
            ['R'] = Gene.Red,
            ['O'] = Gene.Orange,
            ['Y'] = Gene.Yellow,
            ['W'] = Gene.White,
            ['S'] = Gene.Shade,
        };

        public Locus(IEnumerable<char> traits)
        {
            Traits = traits.OrderBy(t => t).ToArray();
            Gene = GeneMapping[char.ToUpper(Traits.First())];
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