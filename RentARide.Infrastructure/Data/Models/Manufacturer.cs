using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Infrastructure.Data.Models
{
    public class Manufacturer
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
