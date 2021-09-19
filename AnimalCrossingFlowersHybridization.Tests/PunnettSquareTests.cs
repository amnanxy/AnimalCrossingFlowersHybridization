using FluentAssertions;
using NUnit.Framework;

namespace AnimalCrossingFlowersHybridization.Tests
{
    [TestFixture]
    public class PunnettSquareTests
    {
        [SetUp]
        public void SetUp()
        {
            _punnettSquare = new PunnettSquare();
        }

        private PunnettSquare _punnettSquare;

        [Test]
        public void Monohybrid_Cross()
        {
            var genotype1 = CreateGenotype(CreateLocus('R', 'r'));
            var genotype2 = CreateGenotype(CreateLocus('R', 'r'));

            var actual = _punnettSquare.Compute(genotype1, genotype2);

            var expected = new[]
            {
                CreateGenotype(CreateLocus('R', 'R')),
                CreateGenotype(CreateLocus('R', 'r')),
                CreateGenotype(CreateLocus('R', 'r')),
                CreateGenotype(CreateLocus('r', 'r')),
            };

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Dihybrid_Cross()
        {
            var genotype1 = CreateGenotype(CreateLocus('R', 'r'), CreateLocus('Y', 'y'));
            var genotype2 = CreateGenotype(CreateLocus('R', 'r'), CreateLocus('Y', 'y'));

            var actual = _punnettSquare.Compute(genotype1, genotype2);

            var expected = new[]
            {
                // RRYY, RRYy, RrYY, RrYy
                CreateGenotype(CreateLocus('R', 'R'), CreateLocus('Y', 'Y')),
                CreateGenotype(CreateLocus('R', 'R'), CreateLocus('Y', 'y')),
                CreateGenotype(CreateLocus('R', 'r'), CreateLocus('Y', 'Y')),
                CreateGenotype(CreateLocus('R', 'r'), CreateLocus('Y', 'y')),
                // RRYy, RRyy, RrYy, Rryy
                CreateGenotype(CreateLocus('R', 'R'), CreateLocus('Y', 'y')),
                CreateGenotype(CreateLocus('R', 'R'), CreateLocus('y', 'y')),
                CreateGenotype(CreateLocus('R', 'r'), CreateLocus('Y', 'y')),
                CreateGenotype(CreateLocus('R', 'r'), CreateLocus('y', 'y')),
                // RrYY, RrYy, rrYY, rrYy,
                CreateGenotype(CreateLocus('R', 'r'), CreateLocus('Y', 'Y')),
                CreateGenotype(CreateLocus('R', 'r'), CreateLocus('Y', 'y')),
                CreateGenotype(CreateLocus('r', 'r'), CreateLocus('Y', 'Y')),
                CreateGenotype(CreateLocus('r', 'r'), CreateLocus('Y', 'y')),
                // RrYy, Rryy, rrYy, rryy
                CreateGenotype(CreateLocus('R', 'r'), CreateLocus('Y', 'y')),
                CreateGenotype(CreateLocus('R', 'r'), CreateLocus('y', 'y')),
                CreateGenotype(CreateLocus('r', 'r'), CreateLocus('Y', 'y')),
                CreateGenotype(CreateLocus('r', 'r'), CreateLocus('y', 'y')),
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