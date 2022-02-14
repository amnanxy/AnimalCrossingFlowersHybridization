using System.Collections.Generic;
using AnimalCrossingFlowersHybridization.Common;

namespace AnimalCrossingFlowersHybridization
{
    public class Locus : ValueObject
    {
        private static readonly Dictionary<char, Gene> GeneMapping = new()
        {
            ['R'] = Gene.Red,
            ['r'] = Gene.Red,
            ['O'] = Gene.Orange,
            ['o'] = Gene.Orange,
            ['Y'] = Gene.Yellow,
            ['y'] = Gene.Yellow,
            ['W'] = Gene.White,
            ['w'] = Gene.White,
            ['S'] = Gene.Shade,
            ['s'] = Gene.Shade,
        };

        private static readonly Dictionary<int, char[]> TraitMapping = new()
        {
            ['r' + 'r'] = new[] { 'r', 'r' },
            ['R' + 'r'] = new[] { 'R', 'r' },
            ['R' + 'R'] = new[] { 'R', 'R' },
            ['o' + 'o'] = new[] { 'o', 'o' },
            ['O' + 'o'] = new[] { 'O', 'o' },
            ['O' + 'O'] = new[] { 'O', 'O' },
            ['y' + 'y'] = new[] { 'y', 'y' },
            ['Y' + 'y'] = new[] { 'Y', 'y' },
            ['Y' + 'Y'] = new[] { 'Y', 'Y' },
            ['w' + 'w'] = new[] { 'w', 'w' },
            ['W' + 'w'] = new[] { 'W', 'w' },
            ['W' + 'W'] = new[] { 'W', 'W' },
            ['s' + 's'] = new[] { 's', 's' },
            ['S' + 's'] = new[] { 'S', 's' },
            ['S' + 'S'] = new[] { 'S', 'S' },
        };

        private readonly char[] _traits;
        private static readonly Dictionary<int, Locus> Cache = new();

        private Locus(int traits)
        {
            _traits = TraitMapping[traits];
            Gene = GeneMapping[_traits[0]];
        }

        public Gene Gene { get; }

        public IEnumerable<char> Traits => _traits;

        public static Locus Create(char gene1, char gene2)
        {
            return Create(gene1 + gene2);
        }

        private static Locus Create(int traits)
        {
            if (Cache.ContainsKey(traits)) return Cache[traits];

            return Cache[traits] = new Locus(traits);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Gene;
            yield return ToString();
        }

        public override string ToString()
        {
            return new string(_traits);
        }
    }
}