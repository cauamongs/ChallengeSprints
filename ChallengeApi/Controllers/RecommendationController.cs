using Microsoft.AspNetCore.Mvc;
using ChallengeApi.Services;
using System.Threading.Tasks;
using ChallengeApi.Models;

namespace ChallengeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpPost("train")]
        public async Task<IActionResult> TrainModel()
        {
            await _recommendationService.TrainModelAsync();
            return Ok("Modelo treinado com sucesso.");
        }

        [HttpPost("recommend")]
        public IActionResult GetRecommendation([FromBody] OfferInput offerInput)
        {
            var recommendation = _recommendationService.Recommend(offerInput);
            return Ok(recommendation);
        }
    }
}
