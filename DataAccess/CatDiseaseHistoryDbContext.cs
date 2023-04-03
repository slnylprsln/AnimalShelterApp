using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CatDiseaseHistoryDbContext : DbContext
    {
        public CatDiseaseHistoryDbContext(DbContextOptions<CatDiseaseHistoryDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<CatDiseaseHistory> CatDiseaseHistories { get; set; }
    }
}
