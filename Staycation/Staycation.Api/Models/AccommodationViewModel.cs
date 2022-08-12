using System.ComponentModel.DataAnnotations;
using static Staycation.Api.Data.Models.Accommodation;

namespace Staycation.Api.Data.Models
{
    public class AccommodationViewModel
    {
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string? Subtitle { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required, MaxLength(50)]
        public string Type { get; set; }
        [Required, Range(1, 5, ErrorMessage = "Value for Categorization must be between 1 and 5.")]
        public int Categorization { get; set; }
        [Required, Range(1, 2147483647, ErrorMessage = "Person Count must 1 or higher.")]
        public int PersonCount { get; set; }
        [MaxLength(800)]
        public string? ImageUrl { get; set; }
        [Required]
        public bool FreeCancelation { get; set; } = true;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int LocationId { get; set; }
    }
}
