using Staycation.Api.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Staycation.Api.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        [Required]
        public int PersonCount { get; set; }
        [Required]
        public bool Confirmed { get; set; }
        [Required]
        public int AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; }
    }
}
