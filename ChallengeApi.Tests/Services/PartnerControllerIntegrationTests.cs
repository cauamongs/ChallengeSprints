using Xunit;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using ChallengeApi;
using ChallengeApi.Models;
using System.Text.Json;
using System.Text;

public class PartnerControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PartnerControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
               
            });
        }).CreateClient();
    }

    [Fact]
    public async Task GetPartners_ShouldReturnOkResponse()
    {
        var response = await _client.GetAsync("/api/partners");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.False(string.IsNullOrEmpty(content));
    }

    [Fact]
    public async Task CreatePartner_ShouldReturnCreatedResponse()
    {
        var newPartner = new Partner
        {
            Name = "Parque Ibirapuera",
            Type = "Lazer",
            Location = "São Paulo",
            Offers = new List<Offer>()
        };

        var content = new StringContent(JsonSerializer.Serialize(newPartner), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/partners", content);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.Contains("Parque Ibirapuera", responseContent);
    }
}
