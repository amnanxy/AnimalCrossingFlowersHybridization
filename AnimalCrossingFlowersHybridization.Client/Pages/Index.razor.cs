using System;
using System.Collections.Generic;
using AnimalCrossingFlowersHybridization.Client.ViewModels.Flowers;
using AnimalCrossingFlowersHybridization.Client.ViewModels.Indexes;
using Microsoft.AspNetCore.Components;

namespace AnimalCrossingFlowersHybridization.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        protected IndexViewModel IndexViewModel { get; set; } = new();

        protected IEnumerable<FlowerViewModel> FlowerViewModels { get; private set; }

        protected void SearchFlower()
        {
            var dataBank = DataBank.DataBanks[IndexViewModel.Assortment];
            var searcher = new HybridizationPathSearcher(dataBank);
            var flowers = searcher.SearchColor(dataBank.RareColor, IndexViewModel.Probability / 100m);
            FlowerViewModels = new FlowerViewModelConverter().Convert(flowers);
        }
    }
}