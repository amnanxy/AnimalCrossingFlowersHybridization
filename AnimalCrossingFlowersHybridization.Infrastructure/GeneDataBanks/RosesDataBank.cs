namespace AnimalCrossingFlowersHybridization.Infrastructure.GeneDataBanks
{
    public class RosesDataBank
    {
        static RosesDataBank()
        {
            var parser = new FlowerParser();

            All = GetRawData()
                .Select(parser.Parse)
                .ToArray();

            Seeds = GetSeedsRawData()
                .Select(parser.Parse)
                .ToArray();
            
            RareColor = Color.Blue;
        }

        public static IReadOnlyList<Flower> All { get; }

        public static IReadOnlyList<Flower> Seeds { get; }

        public static Color RareColor { get; }

        private static IEnumerable<string> GetSeedsRawData()
        {
            return new[]
            {
                "Roses,White,rr-yy-Ww-ss",
                "Roses,Yellow,rr-YY-WW-ss",
                "Roses,Red,RR-yy-WW-Ss",
            };
        }

        private static IEnumerable<string> GetRawData()
        {
            return new[]
            {
                "Roses,White,rr-yy-WW-ss",
                "Roses,White,rr-yy-WW-Ss",
                "Roses,White,rr-yy-WW-SS",
                "Roses,White,rr-yy-Ww-ss",
                "Roses,White,rr-yy-Ww-Ss",
                "Roses,White,rr-yy-Ww-SS",
                "Roses,Purple,rr-yy-ww-ss",
                "Roses,Purple,rr-yy-ww-Ss",
                "Roses,Purple,rr-yy-ww-SS",
                "Roses,Yellow,rr-Yy-WW-ss",
                "Roses,Yellow,rr-Yy-WW-Ss",
                "Roses,Yellow,rr-Yy-WW-SS",
                "Roses,White,rr-Yy-Ww-ss",
                "Roses,White,rr-Yy-Ww-Ss",
                "Roses,White,rr-Yy-Ww-SS",
                "Roses,Purple,rr-Yy-ww-ss",
                "Roses,Purple,rr-Yy-ww-Ss",
                "Roses,Purple,rr-Yy-ww-SS",
                "Roses,Yellow,rr-YY-WW-ss",
                "Roses,Yellow,rr-YY-WW-Ss",
                "Roses,Yellow,rr-YY-WW-SS",
                "Roses,Yellow,rr-YY-Ww-ss",
                "Roses,Yellow,rr-YY-Ww-Ss",
                "Roses,Yellow,rr-YY-Ww-SS",
                "Roses,White,rr-YY-ww-ss",
                "Roses,White,rr-YY-ww-Ss",
                "Roses,White,rr-YY-ww-SS",
                "Roses,Red,Rr-yy-WW-ss",
                "Roses,Pink,Rr-yy-WW-Ss",
                "Roses,White,Rr-yy-WW-SS",
                "Roses,Red,Rr-yy-Ww-ss",
                "Roses,Pink,Rr-yy-Ww-Ss",
                "Roses,White,Rr-yy-Ww-SS",
                "Roses,Red,Rr-yy-ww-ss",
                "Roses,Pink,Rr-yy-ww-Ss",
                "Roses,Purple,Rr-yy-ww-SS",
                "Roses,Orange,Rr-Yy-WW-ss",
                "Roses,Yellow,Rr-Yy-WW-Ss",
                "Roses,Yellow,Rr-Yy-WW-SS",
                "Roses,Red,Rr-Yy-Ww-ss",
                "Roses,Pink,Rr-Yy-Ww-Ss",
                "Roses,White,Rr-Yy-Ww-SS",
                "Roses,Red,Rr-Yy-ww-ss",
                "Roses,Pink,Rr-Yy-ww-Ss",
                "Roses,Purple,Rr-Yy-ww-SS",
                "Roses,Orange,Rr-YY-WW-ss",
                "Roses,Yellow,Rr-YY-WW-Ss",
                "Roses,Yellow,Rr-YY-WW-SS",
                "Roses,Orange,Rr-YY-Ww-ss",
                "Roses,Yellow,Rr-YY-Ww-Ss",
                "Roses,Yellow,Rr-YY-Ww-SS",
                "Roses,Red,Rr-YY-ww-ss",
                "Roses,Pink,Rr-YY-ww-Ss",
                "Roses,White,Rr-YY-ww-SS",
                "Roses,Black,RR-yy-WW-ss",
                "Roses,Red,RR-yy-WW-Ss",
                "Roses,Pink,RR-yy-WW-SS",
                "Roses,Black,RR-yy-Ww-ss",
                "Roses,Red,RR-yy-Ww-Ss",
                "Roses,Pink,RR-yy-Ww-SS",
                "Roses,Black,RR-yy-ww-ss",
                "Roses,Red,RR-yy-ww-Ss",
                "Roses,Pink,RR-yy-ww-SS",
                "Roses,Orange,RR-Yy-WW-ss",
                "Roses,Orange,RR-Yy-WW-Ss",
                "Roses,Yellow,RR-Yy-WW-SS",
                "Roses,Red,RR-Yy-Ww-ss",
                "Roses,Red,RR-Yy-Ww-Ss",
                "Roses,White,RR-Yy-Ww-SS",
                "Roses,Black,RR-Yy-ww-ss",
                "Roses,Red,RR-Yy-ww-Ss",
                "Roses,Purple,RR-Yy-ww-SS",
                "Roses,Orange,RR-YY-WW-ss",
                "Roses,Orange,RR-YY-WW-Ss",
                "Roses,Yellow,RR-YY-WW-SS",
                "Roses,Orange,RR-YY-Ww-ss",
                "Roses,Orange,RR-YY-Ww-Ss",
                "Roses,Yellow,RR-YY-Ww-SS",
                "Roses,Blue,RR-YY-ww-ss",
                "Roses,Red,RR-YY-ww-Ss",
                "Roses,White,RR-YY-ww-SS",
            };
        }
    }
}