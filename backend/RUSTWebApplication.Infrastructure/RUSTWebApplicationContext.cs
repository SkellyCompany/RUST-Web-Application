using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.Entity.Authentication;

namespace RUSTWebApplication.Infrastructure
{
    public class RUSTWebApplicationContext : DbContext
    {
		public RUSTWebApplicationContext(DbContextOptions<RUSTWebApplicationContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<User> Users { get; set; }
	}
}
