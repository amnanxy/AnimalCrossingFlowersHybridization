using System;
using System.Collections.Generic;

namespace AnimalCrossingFlowersHybridization.Client.ViewModels.Flowers
{
    public class FlowerViewModel
    {
        public int No { get; init; }

        public string Name { get; init; }

        public string Color { get; init; }

        public string Genotype { get; init; }

        public decimal Probability { get; init; } = 1;

        public IReadOnlyList<FlowerViewModel> Parents { get; init; } = Array.Empty<FlowerViewModel>();
    }
}