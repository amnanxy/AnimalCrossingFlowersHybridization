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

        public IReadOnlyList<Genotype> Cross(Genotype genotype)
        {
            return GetGametes()
                .SelectMany(gamete1 => genotype
                    .GetGametes()
                    .Select(gamete2 => new Genotype(
                            gamete1.Genes.Zip(gamete2.Genes, (gene1, gene2) => new Locus(new[] { gene1, gene2 }))
                        )
                    )
                ).ToArray();
        }

        private IEnumerable<Gamete> GetGametes()
        {
            return Locus
                .Aggregate<Locus, Meiosis>(null, (current, locus) => new Meiosis(locus, current))
                .Select(genes => new Gamete(genes));
        }

        private record Gamete(IEnumerable<char> Genes);
    }
}