using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentARide.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Infrastructure.Data.SeedDb
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder
                .HasOne(v => v.Category)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(v => v.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(v => v.Manufacturer)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(v => v.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(v => v.Agent)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(v => v.AgentId)
                .OnDelete(DeleteBehavior.Cascade);

            var data = new SeedData();
            builder.HasData(new Vehicle[] {data.FirstVehicle, data.SecondVehicle, data.ThirdVehicle});
        }
    }
}
