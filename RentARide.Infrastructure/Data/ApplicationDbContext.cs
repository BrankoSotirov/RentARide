using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentARide.Infrastructure.Data.Models;
using RentARide.Infrastructure.Data.SeedDb;

namespace RentARide.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public ApplicationDbContext()
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new EngineConfiguration());
            builder.ApplyConfiguration(new ManufacturerConfiguration());

            base.OnModelCreating(builder);
		}
		public DbSet<Vehicle> Vehicles { get; set; }

		public DbSet<Agent> Agents { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Engine> Engines { get; set; }

		public DbSet<Manufacturer> Manufacturers { get; set; }
	}
}
