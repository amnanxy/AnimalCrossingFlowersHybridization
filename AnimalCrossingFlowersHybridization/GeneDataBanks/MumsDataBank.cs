using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization.GeneDataBanks
{
    public class MumsDataBank
    {
        static MumsDataBank()
        {
            var parser = new FlowerParser();

            All = GetRawData()
                .Select(parser.Parse)
                .ToArray();

            Seeds = GetSeedsRawData()
                .Select(parser.Parse)
                .ToArray();
            
            RareColor = Color.Green;
        }

        public static IReadOnlyList<Flower> All { get; }

        public static IReadOnlyList<Flower> Seeds { get; }

        public static Color RareColor { get; }

        private static IEnumerable<string> GetSeedsRawData()
        {
            return new[]
            {
                "Mums,White,rr-yy-Ww",
                "Mums,Yellow,rr-YY-WW",
                "Mums,Red,RR-yy-WW",
            };
        }

        private static IEnumerable<string> GetRawData()
        {
            return new[]
            {
                "Mums,White,rr-yy-WW",
                "Mums,White,rr-yy-Ww",
                "Mums,Purple,rr-yy-ww",
                "Mums,Yellow,rr-Yy-WW",
                "Mums,Yellow,rr-Yy-Ww",
                "Mums,White,rr-Yy-ww",
                "Mums,Yellow,rr-YY-WW",
                "Mums,Yellow,rr-YY-Ww",
                "Mums,Yellow,rr-YY-ww",
                "Mums,Pink,Rr-yy-WW",
                "Mums,Pink,Rr-yy-Ww",
                "Mums,Pink,Rr-yy-ww",
                "Mums,Yellow,Rr-Yy-WW",
                "Mums,Red,Rr-Yy-Ww",
                "Mums,Pink,Rr-Yy-ww",
                "Mums,Purple,Rr-YY-WW",
                "Mums,Purple,Rr-YY-Ww",
                "Mums,Purple,Rr-YY-ww",
                "Mums,Red,RR-yy-WW",
                "Mums,Red,RR-yy-Ww",
                "Mums,Red,RR-yy-ww",
                "Mums,Purple,RR-Yy-WW",
                "Mums,Purple,RR-Yy-Ww",
                "Mums,Red,RR-Yy-ww",
                "Mums,Green,RR-YY-WW",
                "Mums,Green,RR-YY-Ww",
                "Mums,Red,RR-YY-ww",
            };
        }
    }
}