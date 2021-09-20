using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AnimalCrossingFlowersHybridization.Tests
{
    [TestFixture]
    public class FlowerTests
    {
        [Test]
        public void Cross()
        {
            var parser = new FlowerParser();
            var flower1 = parser.Parse("Hyacinths,Yellow,rr-YY-WW");
            var flower2 = parser.Parse("Hyacinths,Red,RR-yy-Ww");
            var colorMapping = DataBank
                .DataBanks[Assortment.Hyacinths]
                .All
                .ToDictionary(t => t.Genotype, t => t.Color);

            var actual = flower1.Cross(flower2, colorMapping);

            var expected = new Flower[]
            {
                new()
                {
                    Assortment = Assortment.Hyacinths,
                    Color = Color.Orange,
                    Generation = 2,
                    Genotype = CreateGenotype(CreateLocus('R', 'r'), CreateLocus('Y', 'y'), CreateLocus('W', 'W')),
                    Probability = 0.5m,
                    Parents = new[] { flower1, flower2 },
                },
                new()
                {
                    Assortment = Assortment.Hyacinths,
                    Color = Color.Yellow,
                    Generation = 2,
                    Genotype = CreateGenotype(CreateLocus('R', 'r'), CreateLocus('Y', 'y'), CreateLocus('W', 'w')),
                    Probability = 0.5m,
                    Parents = new[] { flower1, flower2 },
                },
            };

            actual.Should().BeEquivalentTo(expected);
        }

        private static Locus CreateLocus(char gene1, char gene2)
        {
            return new Locus(new[] { gene1, gene2 });
        }

        private static Genotype CreateGenotype(params Locus[] locus)
        {
            return new Genotype(locus);
        }
    }
}