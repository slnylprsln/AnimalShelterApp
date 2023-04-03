using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions<CatDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CatDiseaseHistory>()
                .HasKey(c => new { c.CatDiseaseHistoryId, c.CatId });
            builder.Entity<CatTesting>()
                .HasKey(c => new { c.CatTestingId, c.CatId });
            builder.Entity<CatVaccination>()
                .HasKey(c => new { c.CatVaccinationId, c.CatId });
            base.OnModelCreating(builder);
        }
        public DbSet<Cat> Cats { get; set; }
    }
}
