using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentARide.Infrastructure.Data.Models;

namespace RentARide.Infrastructure.Data.SeedDb
{
    internal class EngineConfiguration : IEntityTypeConfiguration<Engine>
    {

        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            var data = new SeedData();

            builder.HasData(new Engine[] {data.PetrolEngine, data.HybridEngine, data.DieselEngine, data.ElectricEngine});
        }
    }
}
