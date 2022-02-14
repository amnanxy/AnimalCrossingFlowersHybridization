namespace AnimalCrossingFlowersHybridization.Infrastructure.GeneDataBanks
{
    public class WindflowersDataBank
    {
        static WindflowersDataBank()
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
                "Windflowers,White,rr-oo-Ww",
                "Windflowers,Orange,rr-OO-WW",
                "Windflowers,Red,RR-oo-WW",
            };
        }

        private static IEnumerable<string> GetRawData()
        {
            return new[]
            {
                "Windflowers,White,rr-oo-WW",
                "Windflowers,White,rr-oo-Ww",
                "Windflowers,Blue,rr-oo-ww",
                "Windflowers,Orange,rr-Oo-WW",
                "Windflowers,Orange,rr-Oo-Ww",
                "Windflowers,Blue,rr-Oo-ww",
                "Windflowers,Orange,rr-OO-WW",
                "Windflowers,Orange,rr-OO-Ww",
                "Windflowers,Orange,rr-OO-ww",
                "Windflowers,Red,Rr-oo-WW",
                "Windflowers,Red,Rr-oo-Ww",
                "Windflowers,Blue,Rr-oo-ww",
                "Windflowers,Pink,Rr-Oo-WW",
                "Windflowers,Pink,Rr-Oo-Ww",
                "Windflowers,Pink,Rr-Oo-ww",
                "Windflowers,Orange,Rr-OO-WW",
                "Windflowers,Orange,Rr-OO-Ww",
                "Windflowers,Orange,Rr-OO-ww",
                "Windflowers,Red,RR-oo-WW",
                "Windflowers,Red,RR-oo-Ww",
                "Windflowers,Purple,RR-oo-ww",
                "Windflowers,Red,RR-Oo-WW",
                "Windflowers,Red,RR-Oo-Ww",
                "Windflowers,Purple,RR-Oo-ww",
                "Windflowers,Pink,RR-OO-WW",
                "Windflowers,Pink,RR-OO-Ww",
                "Windflowers,Purple,RR-OO-ww",
            };
        }
    }
}