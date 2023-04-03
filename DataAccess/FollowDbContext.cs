using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class FollowDbContext : DbContext
	{
		public FollowDbContext(DbContextOptions<FollowDbContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
		public DbSet<Follow> Follows { get; set; }
	}
}
