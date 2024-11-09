using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentARide.Infrastructure.Data.Models;

namespace RentARide.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Vehicle>()
                .HasOne(v => v.Category)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(v => v.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder .Entity<Vehicle>()
                .HasOne(v => v.Manufacturer)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(v => v.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder .Entity<Vehicle>()
                .HasOne(v => v.Agent)
                .WithMany()
                .HasForeignKey(v => v.AgentId)
                .OnDelete(DeleteBehavior.Restrict);
             
            base.OnModelCreating(builder);
        }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Agent > Agents { get; set; }  

        public DbSet <Category> Categories{ get; set; }

        public DbSet <Engine> Engines { get; set; }

        public DbSet <Manufacturer> Manufacturers { get; set; }
    }
}
