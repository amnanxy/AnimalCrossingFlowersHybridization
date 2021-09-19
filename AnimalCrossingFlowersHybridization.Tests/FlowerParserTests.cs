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
                    new(new[] { 'r', 'r' }),
                    new(new[] { 'y', 'y' }),
                    new(new[] { 'W', 'w' }),
                }),
            };

            actual.Should().Be(expected);
        }
    }
}