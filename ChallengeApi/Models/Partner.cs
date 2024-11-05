namespace ChallengeApi.Models
{
    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } 
        public string Location { get; set; } 
        public List<Offer> Offers { get; set; }
    }
}
