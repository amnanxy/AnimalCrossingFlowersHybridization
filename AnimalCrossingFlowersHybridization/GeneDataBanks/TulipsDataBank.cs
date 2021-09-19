using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization.GeneDataBanks
{
    public class TulipsDataBank
    {
        static TulipsDataBank()
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
                "Tulips,White,rr-yy-Ss",
                "Tulips,Yellow,rr-YY-ss",
                "Tulips,Red,RR-yy-Ss",
            };
        }

        private static IEnumerable<string> GetRawData()
        {
            return new[]
            {
                "Tulips,White,rr-yy-ss",
                "Tulips,White,rr-yy-Ss",
                "Tulips,White,rr-yy-SS",
                "Tulips,Yellow,rr-Yy-ss",
                "Tulips,Yellow,rr-Yy-Ss",
                "Tulips,White,rr-Yy-SS",
                "Tulips,Yellow,rr-YY-ss",
                "Tulips,Yellow,rr-YY-Ss",
                "Tulips,Yellow,rr-YY-SS",
                "Tulips,Red,Rr-yy-ss",
                "Tulips,Pink,Rr-yy-Ss",
                "Tulips,White,Rr-yy-SS",
                "Tulips,Orange,Rr-Yy-ss",
                "Tulips,Yellow,Rr-Yy-Ss",
                "Tulips,Yellow,Rr-Yy-SS",
                "Tulips,Orange,Rr-YY-ss",
                "Tulips,Yellow,Rr-YY-Ss",
                "Tulips,Yellow,Rr-YY-SS",
                "Tulips,Black,RR-yy-ss",
                "Tulips,Red,RR-yy-Ss",
                "Tulips,Red,RR-yy-SS",
                "Tulips,Black,RR-Yy-ss",
                "Tulips,Red,RR-Yy-Ss",
                "Tulips,Red,RR-Yy-SS",
                "Tulips,Purple,RR-YY-ss",
                "Tulips,Purple,RR-YY-Ss",
                "Tulips,Purple,RR-YY-SS",
            };
        }
    }
}