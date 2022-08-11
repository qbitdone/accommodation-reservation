using Staycation.Api.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Staycation.Api.Models
{
    public class Location
    {
        public int Id { get; set; }
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }
        
        public int PostalCode { get; set; }

        public List<Accommodation> Accommodations { get; set; }
    }
}
