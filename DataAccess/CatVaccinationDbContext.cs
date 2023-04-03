using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CatVaccinationDbContext : DbContext
    {
        public CatVaccinationDbContext(DbContextOptions<CatVaccinationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<CatVaccination> CatVaccinations { get; set; }
    }
}
