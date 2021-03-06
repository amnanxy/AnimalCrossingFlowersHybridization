using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization
{
    internal class Hybridizer
    {
        private readonly IReadOnlyDictionary<string, Color> _colorMapping;
        private readonly Dictionary<string, Flower> _holdingFlowers;
        private readonly Func<Flower, bool> _matchCondition;
        private readonly decimal _probabilityLimit;
        private readonly Color _rareColor;

        public Hybridizer(
            IReadOnlyDictionary<string, Color> colorMapping,
            Color rareColor,
            decimal probabilityLimit,
            Func<Flower, bool> matchCondition
        )
        {
            _colorMapping = colorMapping;
            _rareColor = rareColor;
            _probabilityLimit = probabilityLimit;
            _matchCondition = matchCondition;
            _holdingFlowers = new Dictionary<string, Flower>();
        }

        public IEnumerable<Flower> Execute(IReadOnlyList<Flower> parentFlowers)
        {
            var results = parentFlowers
                .Where(_matchCondition);

            if (results.Any()) return results;

            var childFlowers = Hybridize(parentFlowers);

            return childFlowers.Any()
                ? Execute(childFlowers)
                : Array.Empty<Flower>();
        }

        private IReadOnlyList<Flower> Hybridize(IReadOnlyList<Flower> parentFlowers)
        {
            return HybridizeWithHoldingFlowers(parentFlowers)
                .SelectMany(t => t)
                .OrderByDescending(t => t.Probability)
                .GroupBy(t => t.Genotype.ToString())
                .Select(t => t.First())
                .ToArray();
        }

        private IEnumerable<IEnumerable<Flower>> HybridizeWithHoldingFlowers(IReadOnlyList<Flower> parentFlowers)
        {
            foreach (var parentFlower in parentFlowers.Where(t => t.Color != _rareColor))
            {
                _holdingFlowers.Add(parentFlower.Genotype.ToString(), parentFlower);
                foreach (var holdingFlower in _holdingFlowers.Values.Reverse())
                {
                    yield return parentFlower
                        .Cross(holdingFlower, _colorMapping)
                        .GroupBy(t => t.Color)
                        .Where(t => t.Count() == 1
                                    && !_holdingFlowers.ContainsKey(t.First().Genotype.ToString())
                                    && parentFlowers.All(s => s.Genotype.ToString() != t.First().Genotype.ToString())
                                    && t.First().Probability >= _probabilityLimit)
                        .Select(t => t.First());
                }
            }
        }
    }
}