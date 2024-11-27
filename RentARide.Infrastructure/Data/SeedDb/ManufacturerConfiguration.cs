using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentARide.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Infrastructure.Data.SeedDb
{
    internal class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            var data = new SeedData();

            builder.HasData(new Manufacturer[] {data.AudiManufacturer, data.HondaManufacturer, data.MercedesManufacturer, data.VwManufacturer, data.HyundaiManufacturer});
        }
    }
}
