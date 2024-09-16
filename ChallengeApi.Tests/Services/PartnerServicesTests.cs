using Xunit;
using ChallengeApi.Models;
using ChallengeApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace ChallengeApi.Tests.Services
{
    public class PartnerServiceTests
    {
        private FIAPDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<FIAPDbContext>()
                .UseInMemoryDatabase(databaseName: "ChallengeApiTestDb")
                .Options;

            return new FIAPDbContext(options);
        }

        [Fact]
        public async Task AddPartnerAsync_ShouldAddPartnerSuccessfully()
        {
            var context = GetInMemoryDbContext();
            var service = new PartnerService(context);

            var newPartner = new Partner
            {
                Name = "Parque Ibirapuera",
                Type = "Lazer",
                Location = "São Paulo",
                Offers = new List<Offer>()
            };

            await service.AddPartnerAsync(newPartner);

            var partnerInDb = context.Partners.FirstOrDefault(p => p.Name == "Parque Ibirapuera");
            Assert.NotNull(partnerInDb);
            Assert.Equal("Parque Ibirapuera", partnerInDb.Name);
        }

        [Fact]
        public async Task GetPartnerByIdAsync_ShouldReturnPartner_WhenPartnerExists()
        {
            var context = GetInMemoryDbContext();
            var service = new PartnerService(context);

            var newPartner = new Partner
            {
                Name = "Parque Ibirapuera",
                Type = "Lazer",
                Location = "São Paulo",
                Offers = new List<Offer>()
            };

            await service.AddPartnerAsync(newPartner);

            var result = await service.GetPartnerByIdAsync(newPartner.Id);

            Assert.NotNull(result);
            Assert.Equal("Parque Ibirapuera", result.Name);
        }

        [Fact]
        public async Task UpdatePartnerAsync_ShouldUpdatePartnerSuccessfully()
        {
            var context = GetInMemoryDbContext();
            var service = new PartnerService(context);

            var newPartner = new Partner
            {
                Name = "Parque Ibirapuera",
                Type = "Lazer",
                Location = "São Paulo",
                Offers = new List<Offer>()
            };

            await service.AddPartnerAsync(newPartner);

            newPartner.Name = "Parque Ibirapuera Atualizado";
            await service.UpdatePartnerAsync(newPartner);

            var updatedPartner = context.Partners.FirstOrDefault(p => p.Id == newPartner.Id);
            Assert.NotNull(updatedPartner);
            Assert.Equal("Parque Ibirapuera Atualizado", updatedPartner.Name);
        }

        [Fact]
        public async Task DeletePartnerAsync_ShouldRemovePartnerSuccessfully()
        {
            var context = GetInMemoryDbContext();
            var service = new PartnerService(context);

            var newPartner = new Partner
            {
                Name = "Parque Ibirapuera",
                Offers = new List<Offer>()
            };

            await service.AddPartnerAsync(newPartner);

            await service.DeletePartnerAsync(newPartner.Id);

            var partnerInDb = context.Partners.FirstOrDefault(p => p.Id == newPartner.Id);
            Assert.Null(partnerInDb);
        }
    }
}
