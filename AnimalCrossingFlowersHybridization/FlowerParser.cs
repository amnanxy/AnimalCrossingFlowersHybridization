using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCrossingFlowersHybridization
{
    public class FlowerParser
    {
        private static readonly Dictionary<char, Gene> Genes = new()
        {
            ['R'] = Gene.Red,
            ['O'] = Gene.Orange,
            ['Y'] = Gene.Yellow,
            ['W'] = Gene.White,
            ['S'] = Gene.Shade,
        };

        public Flower Parse(string flowerText)
        {
            var texts = flowerText.Split(",");

            return new Flower
            {
                Assortment = Enum.Parse<Assortment>(texts[0], true),
                Color = Enum.Parse<Color>(texts[1], true),
                Generation = 1,
                Genotype = new Genotype(texts[2]
                    .Split("-")
                    .Select(t => new Locus(Genes[t.ToUpper()[0]], new[] { t[0], t[1] }))),
            };
        }
    }
}