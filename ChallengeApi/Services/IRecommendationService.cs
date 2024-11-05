using ChallengeApi.Models;
using System.Threading.Tasks;

namespace ChallengeApi.Services
{
    public interface IRecommendationService
    {
        Task TrainModelAsync();
        OfferPrediction Recommend(OfferInput offerInput);
        Task<OfferPrediction> GetRecommendationsAsync(int userId);
    }
}
