using System.ComponentModel.DataAnnotations;
using static RentARide.Core.Constants.MessageConstants;

namespace RentARide.Core.Models.Vehicle
{
	public class VehicleServiceModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		public string Model { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public short Year { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name =" Price per day")]
		public decimal PricePerDay { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		public short HorsePower { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Image URL")]

		
		public string ImageUrl { get; set; } = string.Empty;

	
		[Display(Name = "Is rented")]
		public bool IsRented { get; set; }	


	}
}