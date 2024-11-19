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
    }
}
