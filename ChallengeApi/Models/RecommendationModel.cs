using ChallengeApi.Models; 
using System;

namespace ChallengeApi.Models
{
    public class RecommendationModel
    {
        public int UserId { get; set; }
        public int OfferId { get; set; }
        public float Rating { get; set; }
    }

}
