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

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Agent > Agents { get; set; }  

        public DbSet <Category> Categories{ get; set; }

        public DbSet <Engine> Engines { get; set; }

        public DbSet <Manufacturer> Manufacturers { get; set; }
    }
}
