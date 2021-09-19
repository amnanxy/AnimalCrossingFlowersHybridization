using System.Collections.Generic;
using AnimalCrossingFlowersHybridization.GeneDataBanks;

namespace AnimalCrossingFlowersHybridization
{
    public class DataBank
    {
        static DataBank()
        {
            DataBanks = new Dictionary<Assortment, DataBank>
            {
                [Assortment.Cosmos] = new() { All = CosmosDataBank.All, Seeds = CosmosDataBank.Seeds },
                [Assortment.Hyacinths] = new() { All = HyacinthsDataBank.All, Seeds = HyacinthsDataBank.Seeds },
                [Assortment.Lilies] = new() { All = LiliesDataBank.All, Seeds = LiliesDataBank.Seeds },
                [Assortment.Mums] = new() { All = MumsDataBank.All, Seeds = MumsDataBank.Seeds },
                [Assortment.Pansies] = new() { All = PansiesDataBank.All, Seeds = PansiesDataBank.Seeds },
                [Assortment.Roses] = new() { All = RosesDataBank.All, Seeds = RosesDataBank.Seeds },
                [Assortment.Tulips] = new() { All = TulipsDataBank.All, Seeds = TulipsDataBank.Seeds },
                [Assortment.Windflowers] = new() { All = WindflowersDataBank.All, Seeds = WindflowersDataBank.Seeds },
            };
        }

        public IReadOnlyList<Flower> All { get; init; }

        public IReadOnlyList<Flower> Seeds { get; init; }

        public static IReadOnlyDictionary<Assortment, DataBank> DataBanks { get; }
    }
}