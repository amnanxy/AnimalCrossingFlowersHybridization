using System.Collections.Generic;

namespace AnimalCrossingFlowersHybridization
{
    public class Flower : ValueObject
    {
        public Assortment Assortment { get; init; }

        public Color Color { get; init; }

        public Genotype Genotype { get; init; }

        public int Generation { get; init; } = 1;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Assortment;
            yield return Genotype;
        }
    }
}