using ChallengeApi.Models;
using ChallengeApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using System.Linq;
using System.Threading.Tasks;

public class RecommendationService : IRecommendationService
{
    private readonly MLContext _mlContext;
    private readonly FIAPDbContext _context;

    public RecommendationService(FIAPDbContext context)
    {
        _mlContext = new MLContext();
        _context = context;
    }

    public async Task TrainModelAsync()
    {
        var offers = await _context.Offers.ToListAsync();

        
        var data = offers.Select(o => new OfferInput
        {
            Description = o.Description,
            Price = o.ValidTo.Ticks, 
            
        }).ToList();

        var trainData = _mlContext.Data.LoadFromEnumerable(data);

        
        var pipeline = _mlContext.Transforms.Text.FeaturizeText("Description")
            .Append(_mlContext.Transforms.NormalizeMeanVariance("Price"))
            .Append(_mlContext.Transforms.Concatenate("Features", "Price"))
            .Append(_mlContext.Regression.Trainers.Sdca(labelColumnName: "Price", maximumNumberOfIterations: 100));

        
        var model = pipeline.Fit(trainData);

        
        _mlContext.Model.Save(model, trainData.Schema, "model.zip");
    }

    public OfferPrediction Recommend(OfferInput offerInput) 
    {
        var loadedModel = _mlContext.Model.Load("model.zip", out var modelInputSchema);

        
        var predictionEngine = _mlContext.Model.CreatePredictionEngine<OfferInput, OfferPrediction>(loadedModel);
        var prediction = predictionEngine.Predict(offerInput);

        // Retornar a previsão com os atributos desejados
        return new OfferPrediction
        {
            Score = prediction.Score,
            RecommendedOffer = offerInput.Description,
            Category = offerInput.Category, 
            Location = offerInput.Location
        };
    }

    public async Task<OfferPrediction> GetRecommendationsAsync(int userId)
    {
        return await Task.FromResult(new OfferPrediction { Score = 0.8f, RecommendedOffer = "Oferta Exemplo" });
    }
}
