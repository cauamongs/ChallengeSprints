

using Microsoft.EntityFrameworkCore;
using ChallengeApi.Models;

public class FIAPDbContext : DbContext
{
    public FIAPDbContext(DbContextOptions<FIAPDbContext> options)
        : base(options)
    {
    }

    public DbSet<Partner> Partners { get; set; }
    public DbSet<Offer> Offers { get; set; }
}
