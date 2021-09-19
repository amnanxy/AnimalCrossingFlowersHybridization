using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization.GeneDataBanks
{
    public class CosmosDataBank
    {
        static CosmosDataBank()
        {
            var parser = new FlowerParser();

            All = GetRawData()
                .Select(parser.Parse)
                .ToArray();

            Seeds = GetSeedsRawData()
                .Select(parser.Parse)
                .ToArray();
        }

        public static IReadOnlyList<Flower> All { get; }

        public static IReadOnlyList<Flower> Seeds { get; }

        private static IEnumerable<string> GetSeedsRawData()
        {
            return new[]
            {
                "Cosmos,White,rr-yy-Ss",
                "Cosmos,Yellow,rr-YY-Ss",
                "Cosmos,Red,RR-yy-ss",
            };
        }

        private static IEnumerable<string> GetRawData()
        {
            return new[]
            {
                "Cosmos,White,rr-yy-ss",
                "Cosmos,White,rr-yy-Ss",
                "Cosmos,White,rr-yy-SS",
                "Cosmos,Yellow,rr-Yy-ss",
                "Cosmos,Yellow,rr-Yy-Ss",
                "Cosmos,White,rr-Yy-SS",
                "Cosmos,Yellow,rr-YY-ss",
                "Cosmos,Yellow,rr-YY-Ss",
                "Cosmos,Yellow,rr-YY-SS",
                "Cosmos,Pink,Rr-yy-ss",
                "Cosmos,Pink,Rr-yy-Ss",
                "Cosmos,Pink,Rr-yy-SS",
                "Cosmos,Orange,Rr-Yy-ss",
                "Cosmos,Orange,Rr-Yy-Ss",
                "Cosmos,Pink,Rr-Yy-SS",
                "Cosmos,Orange,Rr-YY-ss",
                "Cosmos,Orange,Rr-YY-Ss",
                "Cosmos,Orange,Rr-YY-SS",
                "Cosmos,Red,RR-yy-ss",
                "Cosmos,Red,RR-yy-Ss",
                "Cosmos,Red,RR-yy-SS",
                "Cosmos,Orange,RR-Yy-ss",
                "Cosmos,Orange,RR-Yy-Ss",
                "Cosmos,Red,RR-Yy-SS",
                "Cosmos,Black,RR-YY-ss",
                "Cosmos,Black,RR-YY-Ss",
                "Cosmos,Red,RR-YY-SS",
            };
        }
    }
}