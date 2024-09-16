using System.Collections.Generic;

namespace ChallengeApi.Models
{
    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // e.g., Restaurant, Hotel, Tourist Attraction
        public string Location { get; set; }
        public ICollection<Offer> Offers { get; set; } = new List<Offer>();
    }
}
