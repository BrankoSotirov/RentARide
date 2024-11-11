using Microsoft.EntityFrameworkCore;
using RentARide.Core.Contracts.Vehicle;
using RentARide.Core.Models.Home;
using RentARide.Infrastructure.Data.Common;
 
namespace RentARide.Core.Services.Vehicle
{
	public class VehicleService : IVehicleService
	{

		private readonly IRepository repository;

		public VehicleService(IRepository _repository)
		{
			 repository = _repository;
		}
		public async Task<IEnumerable<VehicleIndexServiceModel>> LastThreeVehicles()
		{
			return await repository.AllReadOnly <Infrastructure.Data.Models.Vehicle>()
				.OrderByDescending(x => x.Id)
				.Take(3)
				.Select(x => new VehicleIndexServiceModel()
				{

				}).ToListAsync();
		}
	}
}
