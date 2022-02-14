using System.Linq;
using AnimalCrossingFlowersHybridization.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace AnimalCrossingFlowersHybridization.Tests
{
    [TestFixture]
    public class HybridizationPathSearcherTests
    {
        [Test]
        public void Blue_Pansies()
        {
            var dataBank = DataBank.DataBanks[Assortment.Pansies];
            var searcher = new HybridizationPathSearcher(dataBank);

            var actual = searcher.SearchColor(Color.Blue, 0);

            var expected = new[]
            {
                CreateFlower(
                    Color.Blue,
                    0.25m,
                    CreateGenotype(CreateLocus('r', 'r'), CreateLocus('y', 'y'), CreateLocus('w', 'w')),
                    dataBank.Seeds.First(t => t.Color == Color.White),
                    dataBank.Seeds.First(t => t.Color == Color.White)
                ),
            };
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Purple_Tulips()
        {
            var dataBank = DataBank.DataBanks[Assortment.Tulips];
            var searcher = new HybridizationPathSearcher(dataBank);

            var actual = searcher.SearchColor(Color.Purple, 0);

            var parent = CreateFlower(
                Color.Orange,
                0.5m,
                CreateGenotype(CreateLocus('R', 'r'), CreateLocus('Y', 'y'), CreateLocus('s', 's')),
                dataBank.Seeds.First(t => t.Color == Color.Red),
                dataBank.Seeds.First(t => t.Color == Color.Yellow)
            );
            var expected = new[]
            {
                CreateFlower(
                    Color.Purple,
                    0.0625m,
                    CreateGenotype(CreateLocus('R', 'R'), CreateLocus('Y', 'Y'), CreateLocus('s', 's')),
                    parent, parent
                ),
            };
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Purple_Pansies()
        {
            var dataBank = DataBank.DataBanks[Assortment.Pansies];
            var searcher = new HybridizationPathSearcher(dataBank);

            var actual = searcher.SearchColor(Color.Purple, 0);

            var g2Parent = CreateFlower(
                Color.Blue,
                0.25m,
                CreateGenotype(CreateLocus('r', 'r'), CreateLocus('y', 'y'), CreateLocus('w', 'w')),
                dataBank.Seeds.First(t => t.Color == Color.White),
                dataBank.Seeds.First(t => t.Color == Color.White)
            );
            var g3Parent = CreateFlower(
                Color.Red,
                1,
                CreateGenotype(CreateLocus('R', 'r'), CreateLocus('y', 'y'), CreateLocus('W', 'w')),
                g2Parent,
                dataBank.Seeds.First(t => t.Color == Color.Red)
            );
            var expected = new[]
            {
                CreateFlower(
                    Color.Purple,
                    0.0625m,
                    CreateGenotype(CreateLocus('R', 'R'), CreateLocus('y', 'y'), CreateLocus('w', 'w')),
                    g3Parent, g3Parent
                ),
            };
            actual.Should().BeEquivalentTo(expected);
        }

        [TestCase(0, 1)]
        [TestCase(0.02, 0)]
        public void Search_Color_With_Probability_Exceeding_Lower_Limit(decimal probabilityLimit, int flowerQty)
        {
            var dataBank = DataBank.DataBanks[Assortment.Roses];
            var searcher = new HybridizationPathSearcher(dataBank);

            var results = searcher.SearchColor(Color.Blue, probabilityLimit);

            results.Count().Should().Be(flowerQty);
        }

        [Test]
        public void Search_Genotype()
        {
            var dataBank = DataBank.DataBanks[Assortment.Roses];
            var searcher = new HybridizationPathSearcher(dataBank);

            var genotype = CreateGenotype(
                CreateLocus('R', 'r'), CreateLocus('Y', 'Y'), CreateLocus('w', 'w'), CreateLocus('s', 's')
            );
            var results = searcher.SearchGenotype(genotype, 0);

            results.Count().Should().Be(0);
        }

        [Test]
        public void Self_Hybridization_Has_High_Priority()
        {
            var dataBank = DataBank.DataBanks[Assortment.Hyacinths];
            var searcher = new HybridizationPathSearcher(dataBank);

            var results = searcher.SearchColor(dataBank.RareColor, 0.07m);

            results.First().Parents.First().Parents.All(t => t.Color == Color.Orange).Should().BeTrue();
        }

        private static Flower CreateFlower(Color color, decimal probability, Genotype genotype, params Flower[] parents)
        {
            return new Flower
            {
                Assortment = parents.First().Assortment,
                Color = color,
                Generation = parents.Max(t => t.Generation) + 1,
                Genotype = genotype,
                Probability = probability,
                Parents = parents,
            };
        }

        private static Locus CreateLocus(char gene1, char gene2)
        {
            return Locus.Create(gene1, gene2);
        }

        private static Genotype CreateGenotype(params Locus[] locus)
        {
            return new Genotype(locus);
        }
    }
}