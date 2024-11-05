using ChallengeApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeApi.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly FIAPDbContext _context;

        public PartnerService(FIAPDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Partner>> GetAllPartnersWithOffersAsync()
        {
            
            return await _context.Partners
                .Include(p => p.Offers)
                .ToListAsync();
        }

        public async Task<Partner> GetPartnerByIdAsync(int id)
        {
            return await _context.Partners.FindAsync(id);
        }

        public async Task AddPartnerAsync(Partner partner)
        {
            await _context.Partners.AddAsync(partner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePartnerAsync(Partner partner)
        {
            _context.Partners.Update(partner);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePartnerAsync(int id)
        {
            var partner = await _context.Partners.FindAsync(id);
            if (partner != null)
            {
                _context.Partners.Remove(partner);
                await _context.SaveChangesAsync();
            }
        }
    }
}