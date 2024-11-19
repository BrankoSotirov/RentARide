using System.ComponentModel.DataAnnotations;
using static RentARide.Core.Constants.MessageConstants;

namespace RentARide.Core.Models.Vehicle
{
    public class VehicleFormModel
	{

		[Required(ErrorMessage = RequiredMessage)]
		//constants
		public string Model { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]

		public string Description { get; set; } = string.Empty ;

		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name  = "Year manufactured")]
		public short Year { get; set; }


		[Required(ErrorMessage = RequiredMessage)]
        public short HorsePower { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Price per day")]
		
        public decimal PricePerDay { get; set; }

		[Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;


		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public IEnumerable<VehicleCateogryServiceModel> Categories { get; set; } = new List<VehicleCateogryServiceModel>();



        [Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Engine Type")]
        public int EngineId { get; set; }
        public IEnumerable<VehicleEngineTypeServiceModel> EngineType { get; set; } = new List<VehicleEngineTypeServiceModel>();


        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        public IEnumerable<VehicleManufacturerServiceModel> Manufacturer { get; set; } = new List<VehicleManufacturerServiceModel>();






    }
}
