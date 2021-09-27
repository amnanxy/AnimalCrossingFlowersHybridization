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
                Genotype = new Genotype(new[]
                {
                    Locus.Create('r', 'r'),
                    Locus.Create('y', 'y'),
                    Locus.Create('W', 'w'),
                }),
            };

            actual.Should().Be(expected);
        }
    }
}