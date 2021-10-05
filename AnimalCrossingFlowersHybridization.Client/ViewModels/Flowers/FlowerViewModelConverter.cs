using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCrossingFlowersHybridization.Client.Extensions;

namespace AnimalCrossingFlowersHybridization.Client.ViewModels.Flowers
{
    public class FlowerViewModelConverter
    {
        private int _number = 1;
        private readonly Dictionary<Genotype, int> _genotypeNumbers = new();
        private readonly HashSet<Genotype> _convertedGenotypes = new();

        public IReadOnlyList<FlowerViewModel> Convert(IEnumerable<Flower> flowers)
        {
            return flowers
                .Select(CreateViewModel)
                .ToArray();
        }

        private FlowerViewModel CreateViewModel(Flower flower)
        {
            return new FlowerViewModel
            {
                No = GetGenotypeNumber(flower),
                Name = $"{flower.Color} {flower.CreateTips()}",
                Color = flower.Color.ToString().ToLower(),
                Genotype = flower.Genotype.ToString(),
                Probability = flower.Probability * 100,
                Parents = CreateParentFlowerViewModels(flower),
            };
        }

        private int GetGenotypeNumber(Flower flower)
        {
            return _genotypeNumbers.TryGetValue(flower.Genotype, out var number)
                ? number
                : _genotypeNumbers[flower.Genotype] = _number++;
        }

        private IReadOnlyList<FlowerViewModel> CreateParentFlowerViewModels(Flower flower)
        {
            if (_convertedGenotypes.Contains(flower.Genotype))
            {
                return Array.Empty<FlowerViewModel>();
            }

            _convertedGenotypes.Add(flower.Genotype);

            return flower
                .Parents
                .Select(CreateViewModel)
                .ToArray();
        }
    }
}