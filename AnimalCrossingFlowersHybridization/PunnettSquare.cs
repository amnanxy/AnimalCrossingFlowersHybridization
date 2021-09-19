using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization
{
    public class PunnettSquare
    {
        public IReadOnlyList<Genotype> Compute(Genotype genotype1, Genotype genotype2)
        {
            return GetGametes(genotype1)
                .SelectMany(
                    gamete1 => GetGametes(genotype2).Select(
                        gamete2 => new Genotype(
                            gamete1.Genes.Zip(gamete2.Genes, (gene1, gene2) => new Locus(new[] { gene1, gene2 }))
                        )
                    )
                ).ToArray();
        }

        private IEnumerable<Gamete> GetGametes(Genotype genotype)
        {
            return genotype.Locus
                .Aggregate<Locus, Meiosis>(null, (current, locus) => new Meiosis(locus, current))
                .Select(genes => new Gamete(genes));
        }

        private record Gamete(IEnumerable<char> Genes);
    }
}