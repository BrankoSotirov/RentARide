using RentARide.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Core.Models.Vehicle
{
    public class AllVehiclesQueryModel
    {

        public int VehiclesPerPage { get; } = 3;

        public string Category { get; set; } = null!;

        public string Engine { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;

        public VehicleSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalVehiclesCount  { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<string> Engines { get; set; } = null!;

        public IEnumerable<string> Manufacturers { get; set; } = null!;



        public IEnumerable<VehicleServiceModel> Vehicles { get; set; } = new List<VehicleServiceModel>();





    }
}
