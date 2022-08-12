using Staycation.Api.Data.Models;

namespace Staycation.Api.Models
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int PersonCount { get; set; }
        public bool Confirmed { get; set; }
        public AccommodationDTO Accommodation { get; set; }
    }
}
