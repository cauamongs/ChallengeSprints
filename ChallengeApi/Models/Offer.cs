using System;

namespace ChallengeApi.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int PartnerId { get; set; }
    }
}
