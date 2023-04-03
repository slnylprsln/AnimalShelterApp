using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DonationDbContext : DbContext
    {
        public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Donation> Donations { get; set; }
    }
}
