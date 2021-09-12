using FluentAssertions;
using NUnit.Framework;

namespace AnimalCrossingFlowersHybridization.Tests
{
    [TestFixture]
    public class HybridizationComputerTests
    {
        [Test]
        public void Blue_Pansies()
        {
            var computer = new HybridizationPathComputer();
            
            var flower = computer.Compute();

            flower.Should().BeEquivalentTo(new Flower());
        }
    }
}