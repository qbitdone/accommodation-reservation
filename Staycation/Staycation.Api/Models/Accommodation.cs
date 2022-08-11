
using Newtonsoft.Json;
using Staycation.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Staycation.Api.Data.Models
{
    // This class represents the Accommodation model
    public class Accommodation
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public AccommodationType Type { get; set; }
        [Required, Range(1, 5, ErrorMessage = "Value for Categorization must be between 1 and 5.")]
        public int Categorization { get; set; }
        [Range(1, 2147483647, ErrorMessage = "Person Count must 1 or higher.")]
        public int PersonCount { get; set; }
        public string ImageUrl { get; set; }
        public bool FreeCancelation { get; set; } = true;
        [Required]
        public decimal Price { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public enum AccommodationType { Room, Apartment, MobileHome }

        public override bool Equals(object? obj)
        {
            return obj is Accommodation accommodation &&
                   Id == accommodation.Id &&
                   Title == accommodation.Title &&
                   Subtitle == accommodation.Subtitle &&
                   Description == accommodation.Description &&
                   EqualityComparer<AccommodationType>.Default.Equals(Type, accommodation.Type) &&
                   Categorization == accommodation.Categorization &&
                   PersonCount == accommodation.PersonCount &&
                   ImageUrl == accommodation.ImageUrl &&
                   FreeCancelation == accommodation.FreeCancelation &&
                   Price == accommodation.Price;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Title);
            hash.Add(Subtitle);
            hash.Add(Description);
            hash.Add(Type);
            hash.Add(Categorization);
            hash.Add(PersonCount);
            hash.Add(ImageUrl);
            hash.Add(FreeCancelation);
            hash.Add(Price);
            return hash.ToHashCode();
        }

        public override string? ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
