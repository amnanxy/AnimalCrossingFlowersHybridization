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
                [Assortment.Cosmos] = new() { All = CosmosDataBank.All, Seeds = CosmosDataBank.Seeds, RareColor = CosmosDataBank.RareColor },
                [Assortment.Hyacinths] = new() { All = HyacinthsDataBank.All, Seeds = HyacinthsDataBank.Seeds, RareColor = HyacinthsDataBank.RareColor },
                [Assortment.Lilies] = new() { All = LiliesDataBank.All, Seeds = LiliesDataBank.Seeds, RareColor = LiliesDataBank.RareColor },
                [Assortment.Mums] = new() { All = MumsDataBank.All, Seeds = MumsDataBank.Seeds, RareColor = MumsDataBank.RareColor },
                [Assortment.Pansies] = new() { All = PansiesDataBank.All, Seeds = PansiesDataBank.Seeds, RareColor = PansiesDataBank.RareColor },
                [Assortment.Roses] = new() { All = RosesDataBank.All, Seeds = RosesDataBank.Seeds, RareColor = RosesDataBank.RareColor  },
                [Assortment.Tulips] = new() { All = TulipsDataBank.All, Seeds = TulipsDataBank.Seeds, RareColor = TulipsDataBank.RareColor  },
                [Assortment.Windflowers] = new() { All = WindflowersDataBank.All, Seeds = WindflowersDataBank.Seeds, RareColor = WindflowersDataBank.RareColor  },
            };
        }

        public IReadOnlyList<Flower> All { get; private init; }

        public IReadOnlyList<Flower> Seeds { get; private init; }

        public Color RareColor { get; private init; }

        public static IReadOnlyDictionary<Assortment, DataBank> DataBanks { get; }
    }
}