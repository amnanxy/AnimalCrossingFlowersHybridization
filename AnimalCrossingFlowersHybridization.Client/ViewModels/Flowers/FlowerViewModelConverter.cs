using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization.Client.ViewModels.Flowers
{
    public class FlowerViewModelConverter
    {
        private int _number = 1;
        private readonly Dictionary<Genotype, int> _dictionary = new();
        private readonly HashSet<Genotype> _converted = new();

        public IReadOnlyList<FlowerViewModel> Convert(IEnumerable<Flower> flowers)
        {
            return flowers
                .Select(CreateViewModel)
                .ToArray();
        }

        private FlowerViewModel CreateViewModel(Flower flower)
        {
            if (!_dictionary.TryGetValue(flower.Genotype, out var number))
            {
                number = _number++;
                _dictionary[flower.Genotype] = number;
            }

            var seedTips = flower.Parents.Any() ? string.Empty : "(seed)";
            FlowerViewModel[] parents;
            if (_converted.Contains(flower.Genotype))
            {
                parents = Array.Empty<FlowerViewModel>();
            }
            else
            {
                parents= flower.Parents.Select(CreateViewModel).ToArray();
                _converted.Add(flower.Genotype);
            }

            return new FlowerViewModel
            {
                No = number,
                Name = $"{flower.Color} {seedTips}",
                Color = flower.Color.ToString().ToLower(),
                Genotype = string.Join("-", flower.Genotype.Locus.Select(t => string.Concat(t.Traits))),
                Probability = flower.Probability * 100,
                Parents = parents,
            };
        }
    }
}