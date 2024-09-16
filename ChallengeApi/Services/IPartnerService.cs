using ChallengeApi.Models;

namespace ChallengeApi.Services
{
    public interface IPartnerService
    {
        Task<IEnumerable<Partner>> GetAllPartnersAsync();
        Task<Partner> GetPartnerByIdAsync(int id);
        Task AddPartnerAsync(Partner partner);
        Task UpdatePartnerAsync(Partner partner);
        Task DeletePartnerAsync(int id);
    }
}
