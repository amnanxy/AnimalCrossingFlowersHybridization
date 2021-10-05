using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization.GeneDataBanks
{
    public class LiliesDataBank
    {
        static LiliesDataBank()
        {
            var parser = new FlowerParser();

            All = GetRawData()
                .Select(parser.Parse)
                .ToArray();

            Seeds = GetSeedsRawData()
                .Select(parser.Parse)
                .ToArray();
            
            RareColor = Color.Black;
        }

        public static IReadOnlyList<Flower> All { get; }

        public static IReadOnlyList<Flower> Seeds { get; }

        public static Color RareColor { get; }

        private static IEnumerable<string> GetSeedsRawData()
        {
            return new[]
            {
                "Lilies,White,rr-yy-SS",
                "Lilies,Yellow,rr-YY-ss",
                "Lilies,Red,RR-yy-Ss",
            };
        }

        private static IEnumerable<string> GetRawData()
        {
            return new[]
            {
                "Lilies,White,rr-yy-ss",
                "Lilies,White,rr-yy-Ss",
                "Lilies,White,rr-yy-SS",
                "Lilies,Yellow,rr-Yy-ss",
                "Lilies,White,rr-Yy-Ss",
                "Lilies,White,rr-Yy-SS",
                "Lilies,Yellow,rr-YY-ss",
                "Lilies,Yellow,rr-YY-Ss",
                "Lilies,White,rr-YY-SS",
                "Lilies,Red,Rr-yy-ss",
                "Lilies,Pink,Rr-yy-Ss",
                "Lilies,White,Rr-yy-SS",
                "Lilies,Orange,Rr-Yy-ss",
                "Lilies,Yellow,Rr-Yy-Ss",
                "Lilies,Yellow,Rr-Yy-SS",
                "Lilies,Orange,Rr-YY-ss",
                "Lilies,Yellow,Rr-YY-Ss",
                "Lilies,Yellow,Rr-YY-SS",
                "Lilies,Black,RR-yy-ss",
                "Lilies,Red,RR-yy-Ss",
                "Lilies,Pink,RR-yy-SS",
                "Lilies,Black,RR-Yy-ss",
                "Lilies,Red,RR-Yy-Ss",
                "Lilies,Pink,RR-Yy-SS",
                "Lilies,Orange,RR-YY-ss",
                "Lilies,Orange,RR-YY-Ss",
                "Lilies,White,RR-YY-SS",
            };
        }
    }
}