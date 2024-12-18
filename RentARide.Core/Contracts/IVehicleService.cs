 using RentARide.Core.Enumerations;
using RentARide.Core.Models.Home;
using RentARide.Core.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Core.Contracts
{
    public interface IVehicleService
    {

        Task<IEnumerable<VehicleIndexServiceModel>> LastThreeVehicles();

        Task<IEnumerable<VehicleCateogryServiceModel>> AllCategories();

        Task<IEnumerable<VehicleEngineTypeServiceModel>> AllEngineTypes();

        Task<IEnumerable<VehicleManufacturerServiceModel>> AllManufacturers();
        
        Task <bool> CategoryExists(int categoryId);
        Task<bool> EngineTypeExists(int engineTypeId);
        Task<bool>ManufacturerExists(int manufacturerId);

        Task <int> Create(VehicleFormModel model, int agentId);

        Task<VehicleQueryServiceModel> All(string? cateogry = null,
            string? searchTerm = null,
            string? manufacturer = null,
            string? engine = null,
            VehicleSorting sorting = VehicleSorting.Newest,
            int currentPage = 1,
            int vehiclesPerPage = 1);



        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<VehicleServiceModel>> AllVehiclesByAgentId (int agentId);

        Task<IEnumerable<VehicleServiceModel>> AllVehiclesByUserId (string userId);
        Task<IEnumerable<string>> AllEngineTypeNames();
		Task<IEnumerable<string>> AllManufacturerNames();

        Task <bool> ExistsAsync(int id);

        Task<VehicleDetailsServiceModel> VehicleDetailsById(int id);

        Task Edit(int vehicleId, VehicleFormModel model);

        Task<bool> HasAgentWithId(int vehicleId, string userId);

        Task <VehicleFormModel?> GetVehicleFormModelById(int Id);

        Task <bool> IsVehicleRented ();


        Task <RentViewModel> GetRentViewModelById(int Id);

        Task LeaveAsync(int id);


        

	}
}
