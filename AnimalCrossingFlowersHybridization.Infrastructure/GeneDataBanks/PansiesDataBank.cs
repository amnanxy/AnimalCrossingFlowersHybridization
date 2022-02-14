namespace AnimalCrossingFlowersHybridization.Infrastructure.GeneDataBanks
{
    public class PansiesDataBank
    {
        static PansiesDataBank()
        {
            var parser = new FlowerParser();

            All = GetRawData()
                .Select(parser.Parse)
                .ToArray();

            Seeds = GetSeedsRawData()
                .Select(parser.Parse)
                .ToArray();
            
            RareColor = Color.Purple;
        }

        public static IReadOnlyList<Flower> All { get; }

        public static IReadOnlyList<Flower> Seeds { get; }

        public static Color RareColor { get; }

        private static IEnumerable<string> GetSeedsRawData()
        {
            return new[]
            {
                "Pansies,White,rr-yy-Ww",
                "Pansies,Yellow,rr-YY-WW",
                "Pansies,Red,RR-yy-WW",
            };
        }

        private static IEnumerable<string> GetRawData()
        {
            return new[]
            {
                "Pansies,White,rr-yy-WW",
                "Pansies,White,rr-yy-Ww",
                "Pansies,Blue,rr-yy-ww",
                "Pansies,Yellow,rr-Yy-WW",
                "Pansies,Yellow,rr-Yy-Ww",
                "Pansies,Blue,rr-Yy-ww",
                "Pansies,Yellow,rr-YY-WW",
                "Pansies,Yellow,rr-YY-Ww",
                "Pansies,Yellow,rr-YY-ww",
                "Pansies,Red,Rr-yy-WW",
                "Pansies,Red,Rr-yy-Ww",
                "Pansies,Blue,Rr-yy-ww",
                "Pansies,Orange,Rr-Yy-WW",
                "Pansies,Orange,Rr-Yy-Ww",
                "Pansies,Orange,Rr-Yy-ww",
                "Pansies,Yellow,Rr-YY-WW",
                "Pansies,Yellow,Rr-YY-Ww",
                "Pansies,Yellow,Rr-YY-ww",
                "Pansies,Red,RR-yy-WW",
                "Pansies,Red,RR-yy-Ww",
                "Pansies,Purple,RR-yy-ww",
                "Pansies,Red,RR-Yy-WW",
                "Pansies,Red,RR-Yy-Ww",
                "Pansies,Purple,RR-Yy-ww",
                "Pansies,Orange,RR-YY-WW",
                "Pansies,Orange,RR-YY-Ww",
                "Pansies,Purple,RR-YY-ww",
            };
        }
    }
}