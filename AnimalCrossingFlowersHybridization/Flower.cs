using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization
{
    public class Flower : ValueObject
    {
        public Assortment Assortment { get; init; }

        public Color Color { get; init; }

        public Genotype Genotype { get; init; }

        public int Generation { get; init; } = 1;

        public decimal Probability { get; init; }

        public IEnumerable<Flower> Parents { get; init; } = Enumerable.Empty<Flower>();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Assortment;
            yield return Genotype;
            yield return Probability;

            foreach (var parent in Parents)
            {
                yield return parent;
            }
        }

        public IReadOnlyList<Flower> Cross(Flower anotherParent, IReadOnlyDictionary<Genotype, Color> colorMapping)
        {
            var genotypes = Genotype.Cross(anotherParent.Genotype);

            return genotypes
                .GroupBy(t => t)
                .Select(t => new Flower
                {
                    Assortment = Assortment,
                    Color = colorMapping[t.Key],
                    Generation = Math.Max(Generation, anotherParent.Generation),
                    Genotype = t.Key,
                    Probability = t.Count() / (decimal)genotypes.Count,
                    Parents = new[] { this, anotherParent },
                })
                .ToArray();
        }
    }
}