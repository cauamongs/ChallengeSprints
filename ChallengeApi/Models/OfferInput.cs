using Microsoft.ML.Data;

namespace ChallengeApi.Models
{
    public class OfferInput
    {
        public string Description { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
    }
}
