using FluentAssertions;
using NUnit.Framework;

namespace AnimalCrossingFlowersHybridization.Tests
{
    [TestFixture]
    public class FlowerParserTests
    {
        [Test]
        public void Parse()
        {
            var parser = new FlowerParser();

            var actual = parser.Parse("Pansies,White,yy-rr-wW");

            var expected = new Flower
            {
                Generation = 1,
                Assortment = Assortment.Pansies,
                Color = Color.White,
                Genotype = new Genotype(new Locus[]
                {
                    new(Gene.Red, new[] { 'r', 'r' }),
                    new(Gene.Yellow, new[] { 'y', 'y' }),
                    new(Gene.White, new[] { 'W', 'w' }),
                }),
            };

            actual.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }
    }
}