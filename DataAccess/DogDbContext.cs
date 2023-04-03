using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DogDbContext : DbContext
    {
        public DogDbContext(DbContextOptions<DogDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DogDiseaseHistory>()
                .HasKey(d => new { d.DogDiseaseHistoryId, d.DogId });
            builder.Entity<DogTesting>()
                .HasKey(d => new { d.DogTestingId, d.DogId });
            builder.Entity<DogVaccination>()
                .HasKey(d => new { d.DogVaccinationId, d.DogId });
            base.OnModelCreating(builder);
        }
        public DbSet<Dog> Dogs { get; set; }
    }
}
