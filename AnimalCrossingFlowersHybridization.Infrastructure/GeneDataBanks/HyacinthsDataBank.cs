namespace AnimalCrossingFlowersHybridization.Infrastructure.GeneDataBanks
{
    public class HyacinthsDataBank
    {
        static HyacinthsDataBank()
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
                "Hyacinths,White,rr-yy-Ww",
                "Hyacinths,Yellow,rr-YY-WW",
                "Hyacinths,Red,RR-yy-Ww",
            };
        }

        private static IEnumerable<string> GetRawData()
        {
            return new[]
            {
                "Hyacinths,White,rr-yy-WW",
                "Hyacinths,White,rr-yy-Ww",
                "Hyacinths,Blue,rr-yy-ww",
                "Hyacinths,Yellow,rr-Yy-WW",
                "Hyacinths,Yellow,rr-Yy-Ww",
                "Hyacinths,White,rr-Yy-ww",
                "Hyacinths,Yellow,rr-YY-WW",
                "Hyacinths,Yellow,rr-YY-Ww",
                "Hyacinths,Yellow,rr-YY-ww",
                "Hyacinths,Red,Rr-yy-WW",
                "Hyacinths,Pink,Rr-yy-Ww",
                "Hyacinths,White,Rr-yy-ww",
                "Hyacinths,Orange,Rr-Yy-WW",
                "Hyacinths,Yellow,Rr-Yy-Ww",
                "Hyacinths,Yellow,Rr-Yy-ww",
                "Hyacinths,Orange,Rr-YY-WW",
                "Hyacinths,Yellow,Rr-YY-Ww",
                "Hyacinths,Yellow,Rr-YY-ww",
                "Hyacinths,Red,RR-yy-WW",
                "Hyacinths,Red,RR-yy-Ww",
                "Hyacinths,Red,RR-yy-ww",
                "Hyacinths,Blue,RR-Yy-WW",
                "Hyacinths,Red,RR-Yy-Ww",
                "Hyacinths,Red,RR-Yy-ww",
                "Hyacinths,Purple,RR-YY-WW",
                "Hyacinths,Purple,RR-YY-Ww",
                "Hyacinths,Purple,RR-YY-ww",
            };
        }
    }
}