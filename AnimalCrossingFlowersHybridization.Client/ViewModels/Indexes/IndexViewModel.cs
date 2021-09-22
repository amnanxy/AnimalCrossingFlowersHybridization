using System.ComponentModel.DataAnnotations;

namespace AnimalCrossingFlowersHybridization.Client.ViewModels.Indexes
{
    public class IndexViewModel
    {
        [Required]
        public Assortment Assortment { get; set; } = Assortment.Cosmos;

        [Required]
        [Range(typeof(decimal), "0", "100")]
        public decimal Probability { get; set; }
    }
}