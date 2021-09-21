using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization
{
    public class HybridizationPathSearcher
    {
        private readonly IReadOnlyDictionary<Genotype, Color> _colorMapping;
        private readonly IReadOnlyList<Flower> _seeds;
        private readonly Color _rareColor;

        public HybridizationPathSearcher(DataBank dataBank)
        {
            _seeds = dataBank.Seeds;
            _rareColor = dataBank.RareColor;
            _colorMapping = dataBank.All.ToDictionary(t => t.Genotype, t => t.Color);
        }

        public IEnumerable<Flower> SearchColor(Color targetColor, decimal probabilityLimit)
        {
            return new Hybridizer(
                _colorMapping,
                _rareColor,
                probabilityLimit,
                flower => flower.Color == targetColor
            ).Execute(_seeds);
        }

        public IEnumerable<Flower> SearchGenotype(Genotype targetGenotype, decimal probabilityLimit)
        {
            return new Hybridizer(
                _colorMapping,
                _rareColor,
                probabilityLimit,
                flower => flower.Genotype == targetGenotype
            ).Execute(_seeds);
        }
    }
}