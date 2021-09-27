using System;
using System.Linq;

namespace AnimalCrossingFlowersHybridization
{
    public class FlowerParser
    {
        public Flower Parse(string flowerText)
        {
            var texts = flowerText.Split(",");

            return new Flower
            {
                Assortment = Enum.Parse<Assortment>(texts[0], true),
                Color = Enum.Parse<Color>(texts[1], true),
                Genotype = new Genotype(texts[2]
                    .Split("-")
                    .Select(t => Locus.Create(t[0], t[1]))),
            };
        }
    }
}