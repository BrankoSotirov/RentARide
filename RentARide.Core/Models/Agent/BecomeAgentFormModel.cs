using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RentARide.Core.Constants.MessageConstants;

namespace RentARide.Core.Models.Agent
{
	public class BecomeAgentFormModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name ="Phone number")]

		[Phone]
		public string PhoneNumber { get; set; } = null!;
	}
}
