using RentARide.Core.Models.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Core.Models.Vehicle
{
	public class VehicleDetailsServiceModel : VehicleServiceModel
	{

		public string Description { get; set; } = null!;

		public string Category { get; set; } = null!;

		public string Manufacturer {  get; set; } = null!;

		public AgentServiceModel Agent { get; set; } = null!;


	}
}
