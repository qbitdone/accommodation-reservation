using static Staycation.Api.Data.Models.Accommodation;

namespace Staycation.Api.Models
{
    public class AccommodationResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public AccommodationType Type { get; set; }
        public int Categorization { get; set; }
        public int PersonCount { get; set; }
        public string ImageUrl { get; set; }
        public bool FreeCancelation { get; set; } = true;
        public decimal Price { get; set; }
        public LocationViewModel Location { get; set; }
    }
}
