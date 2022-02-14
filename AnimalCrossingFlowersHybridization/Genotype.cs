using System.Collections.Generic;
using System.Linq;
using AnimalCrossingFlowersHybridization.Common;

namespace AnimalCrossingFlowersHybridization
{
    public class Genotype : ValueObject
    {
        public Genotype(IEnumerable<Locus> locuses)
        {
            Locuses = locuses.OrderBy(t => t.Gene).ToArray();
        }

        public IEnumerable<Locus> Locuses { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ToString();
        }

        public override string ToString()
        {
            return string.Join("-", Locuses.Select(t => t.ToString()));
        }

        public IReadOnlyList<Genotype> Cross(Genotype genotype)
        {
            var gametes2 = genotype
                .GetGametes()
                .ToArray();

            return GetGametes()
                .SelectMany(gamete1 => gametes2
                    .Select(gamete2 => new Genotype(gamete1.Genes.Zip(gamete2.Genes, Locus.Create)))
                ).ToArray();
        }

        private IEnumerable<Gamete> GetGametes()
        {
            return Locuses
                .Aggregate<Locus, Meiosis>(null, (current, locus) => new Meiosis(locus, current));
        }
    }
}