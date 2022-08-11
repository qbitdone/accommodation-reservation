using Staycation.Api.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Staycation.Api.Models
{
    public class Location
    {
        public int Id { get; set; }
        [MaxLength(800)]
        public string ImageUrl { get; set; }
        [MaxLength(50)]
        public string PostalCode { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public List<Accommodation> Accommodations { get; set; }
    }
}
