using Microsoft.ML.Data;

namespace ChallengeApi.Models
{
    public class OfferPrediction
    {
        [ColumnName("Score")]
        public float Score { get; set; }

        public string RecommendedOffer { get; set; }

        public string Category { get; set; } 
        public string Location { get; set; } 
    }
}
