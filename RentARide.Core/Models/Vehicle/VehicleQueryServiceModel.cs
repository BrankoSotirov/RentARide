using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Core.Models.Vehicle
{
	public class VehicleQueryServiceModel
	{

		public int TotalVehicleCount { get; set; }

		public IEnumerable<VehicleServiceModel> Vehicles { get; set; } = new List<VehicleServiceModel>();
    }
}
