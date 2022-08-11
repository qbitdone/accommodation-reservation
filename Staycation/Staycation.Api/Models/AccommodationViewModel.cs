using System.ComponentModel.DataAnnotations;
using static Staycation.Api.Data.Models.Accommodation;

namespace Staycation.Api.Data.Models
{
    public class AccommodationViewModel
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Subtitle { get; set; }
        public string Description { get; set; }
        [Required, Range(1, 5, ErrorMessage = "Value for Categorization must be between 1 and 5.")]
        public int Categorization { get; set; }
        [Range(1, 2147483647, ErrorMessage = "Person Count must 1 or higher.")]
        public int PersonCount { get; set; }
        public string ImageUrl { get; set; }
        public bool FreeCancelation { get; set; } = true;
        [Required]
        public decimal Price { get; set; }
        public int LocationId { get; set; }
    }
}
