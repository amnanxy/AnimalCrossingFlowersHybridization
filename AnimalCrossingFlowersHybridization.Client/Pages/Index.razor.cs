using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalCrossingFlowersHybridization.Client.ViewModels.Flowers;
using AnimalCrossingFlowersHybridization.Client.ViewModels.Indexes;
using AnimalCrossingFlowersHybridization.Infrastructure;
using Microsoft.AspNetCore.Components;

namespace AnimalCrossingFlowersHybridization.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        protected IndexViewModel IndexViewModel { get; } = new();

        protected IEnumerable<FlowerViewModel> FlowerViewModels { get; private set; }

        protected bool IsLoading { get; private set; }

        protected async Task SearchFlower()
        {
            IsLoading = true;
            FlowerViewModels = await Task.Run(() =>
            {
                var dataBank = DataBank.DataBanks[IndexViewModel.Assortment];
                var searcher = new HybridizationPathSearcher(dataBank);
                var flowers = searcher.SearchColor(dataBank.RareColor, IndexViewModel.Probability / 100m);
                return new FlowerViewModelConverter().Convert(flowers);
            });
            IsLoading = false;
        }
    }
}