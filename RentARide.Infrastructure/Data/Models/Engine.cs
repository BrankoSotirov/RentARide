using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Infrastructure.Data.Models
{
	public class Engine
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Type { get; set; } = string.Empty;
	}
}
