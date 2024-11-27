using Microsoft.EntityFrameworkCore;
using RentARide.Core.Contracts;
using RentARide.Core.Enumerations;
using RentARide.Core.Models.Home;
using RentARide.Core.Models.Vehicle;
using RentARide.Infrastructure.Data.Common;
using RentARide.Infrastructure.Data.Models;

namespace RentARide.Core.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IRepository repository;

        public VehicleService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<VehicleCateogryServiceModel>> AllCategories()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new VehicleCateogryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<VehicleEngineTypeServiceModel>> AllEngineTypes()
        {
            return await repository.AllReadOnly<Engine>()
           .Select(e => new VehicleEngineTypeServiceModel()
           {
               Id = e.Id,
               Type = e.Type,
           })
           .ToListAsync();
        }

        public async Task<IEnumerable<VehicleManufacturerServiceModel>> AllManufacturers()
        {
            return await repository.AllReadOnly<Manufacturer>()
         .Select(m => new VehicleManufacturerServiceModel()
         {
             Id = m.Id,
             Name = m.Name
         })
         .ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }
        public async Task<bool> EngineTypeExists(int engineTypeId)
        {
            return await repository.AllReadOnly<Engine>()
                 .AnyAsync(e => e.Id == engineTypeId);
        }

        public async Task<bool> ManufacturerExists(int manufacturerId)
        {
            return await repository.AllReadOnly<Manufacturer>()
                .AnyAsync(m => m.Id == manufacturerId);
        }
        public async Task<int> Create(VehicleFormModel model,int agentId)
        {
            Vehicle vehicle = new Vehicle()
            {
                Model = model.Model,
                Description = model.Description,
                Year = model.Year,
                HorsePower = model.HorsePower,
                PricePerDay = model.PricePerDay,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                ManufacturerId = model.ManufacturerId,
                AgentId = agentId,
                EngineId = model.EngineId
                
            };
            await repository.Add(vehicle);
            await repository.SaveChanges();
            return vehicle.Id;
        }

        

        public async Task<IEnumerable<VehicleIndexServiceModel>> LastThreeVehicles()
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Vehicle>()
                .OrderByDescending(x => x.Id)
                .Take(3)
                .Select(x => new VehicleIndexServiceModel()
                {

                }).ToListAsync();
        }

        public async Task<VehicleQueryServiceModel> All(string? cateogry = null,
            string searchTerm = null, 
            string manufacturer = null,
            string engine = null,

            VehicleSorting sorting = VehicleSorting.Newest, 
            int currentPage = 1, 
            int vehiclesPerPage = 1)
        {
            var vehiclesToShow = repository.AllReadOnly<Vehicle>();

            if (cateogry != null)
            {
                vehiclesToShow = vehiclesToShow.Where(v => v.Category.Name == cateogry);

            }

            if (manufacturer != null)
            {
                vehiclesToShow = vehiclesToShow.Where(v => v.Manufacturer.Name == manufacturer);

            }

            if (manufacturer != null)
            {
                vehiclesToShow = vehiclesToShow.Where(v => v.Engine.Type == engine);

            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                vehiclesToShow = vehiclesToShow
                     .Where(v => (v.Model.ToLower().Contains(normalizedSearchTerm)
                     || v.Description.ToLower().Contains(normalizedSearchTerm) ));
            }

            vehiclesToShow = sorting switch
            {
                VehicleSorting.Price => vehiclesToShow.OrderByDescending(x => x.PricePerDay),
                VehicleSorting.NotRentedFirst => vehiclesToShow.OrderBy(X => X.RenterId == null)
                .ThenByDescending( X => X.Id),
                _ => vehiclesToShow.OrderByDescending(x => x.Id)

            };

            var vehicles = await vehiclesToShow
                .Skip((currentPage - 1) * vehiclesPerPage)
                .Take(vehiclesPerPage)
                .Select (v => new VehicleServiceModel()
                {
                    Id = v.Id,
                    HorsePower = v.HorsePower,
                    ImageUrl = v.ImageUrl,
                    Model = v.Model,
                    PricePerDay = v.PricePerDay,
                    Year = v.Year,
                    IsRented = v.RenterId != null
                })
                .ToListAsync();

            int totalVehicles = await vehiclesToShow.CountAsync();

            return new VehicleQueryServiceModel()
            {
                Vehicles = vehicles,
                TotalVehicleCount = totalVehicles

            };


		}

		public async Task<IEnumerable<string>> AllCategoriesNames()
		{
			return await repository.AllReadOnly<Category>()
                .Select (c => c.Name)
                .Distinct()
                .ToListAsync();
		}

		public async Task<IEnumerable<string>> AllEngineTypeNames()
		{
            return await repository.AllReadOnly<Engine>()
                .Select(c => c.Type)
                .Distinct()
                .ToListAsync();
        }

		public async Task<IEnumerable<string>> AllManufacturerNames()
		{
            return await repository.AllReadOnly<Manufacturer>()
            .Select(c => c.Name)
            .Distinct()
            .ToListAsync();
        }

      
    }
}
