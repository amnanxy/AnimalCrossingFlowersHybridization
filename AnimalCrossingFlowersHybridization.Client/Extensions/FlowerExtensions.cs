
namespace AnimalCrossingFlowersHybridization.Client.Extensions
{
    internal static class FlowerExtensions
    {
        public static string CreateTips(this Flower flower)
        {
            return flower.IsSeed() ? "(seed)" : string.Empty;
        }
    }
}