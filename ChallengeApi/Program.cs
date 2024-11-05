using ChallengeApi.Models;
using ChallengeApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ChallengeApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllers();

            
            builder.Services.AddDbContext<FIAPDbContext>(options =>
                options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAP")));

            
            builder.Services.AddScoped<IPartnerService, PartnerService>();
            builder.Services.AddScoped<IRecommendationService, RecommendationService>();

            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            
            using (var scope = app.Services.CreateScope())
            {
                var recommendationService = scope.ServiceProvider.GetRequiredService<IRecommendationService>();
                await recommendationService.TrainModelAsync();
            }

            app.Run();
        }
    }
}
