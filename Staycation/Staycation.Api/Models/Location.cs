using Staycation.Api.Data.Models;

namespace Staycation.Api.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostalCode { get; set; }

        public List<Accommodation> Accommodations { get; set; }
    }
}
