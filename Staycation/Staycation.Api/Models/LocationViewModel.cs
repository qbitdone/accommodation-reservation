using System.ComponentModel.DataAnnotations;

namespace Staycation.Api.Models
{
    public class LocationViewModel
    {
        [MaxLength(800)]
        public string ImageUrl { get; set; }
        [MaxLength(50)]
        public int PostalCode { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
