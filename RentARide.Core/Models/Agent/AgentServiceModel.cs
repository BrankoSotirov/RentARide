using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Core.Models.Agent
{
	public class AgentServiceModel
	{
		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; set; } = null!;

		public string Email { get; set; } = null!;
	}
}
