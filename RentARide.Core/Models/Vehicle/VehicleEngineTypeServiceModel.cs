using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Core.Models.Vehicle
{
    public class VehicleEngineTypeServiceModel
    {
       public int Id { get; set; }

        public string Type { get; set; } = string.Empty;
    }
}
