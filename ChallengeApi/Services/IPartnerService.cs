using ChallengeApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeApi.Services
{
    public interface IPartnerService
    {
        Task<IEnumerable<Partner>> GetAllPartnersWithOffersAsync();
        Task<Partner> GetPartnerByIdAsync(int id);
        Task AddPartnerAsync(Partner partner);
        Task UpdatePartnerAsync(Partner partner);
        Task DeletePartnerAsync(int id);
    }
}
