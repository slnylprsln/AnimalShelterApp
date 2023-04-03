using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CatTestingDbContext : DbContext
    {
        public CatTestingDbContext(DbContextOptions<CatTestingDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<CatTesting> CatTestings { get; set; }
    }
}
