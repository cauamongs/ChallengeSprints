using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ChallengeApi;
using ChallengeApi.Services; // Adicione essa diretiva para usar o PartnerService

namespace ChallengeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Configure Entity Framework with Oracle
            builder.Services.AddDbContext<FIAPDbContext>(options =>
                options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAP")));

            // Register PartnerService
            builder.Services.AddScoped<IPartnerService, PartnerService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
