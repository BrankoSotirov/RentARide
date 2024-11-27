using RentARide.Core.Models.Vehicle;

namespace System.Linq
{
    public static  class IQuerableVehicleExtension
    {

        public static IQueryable<VehicleServiceModel> ProjectToHouseServiceModel(this IQueryable<VehicleServiceModel> vehicles)
        {
            return vehicles
                .Select(v => new VehicleServiceModel()
                {
                    Id = v.Id,
                    Model  = v.Model,
                    Year = v.Year,
                    PricePerDay = v.PricePerDay,
                    HorsePower = v.HorsePower,
                    ImageUrl = v.ImageUrl,
                    IsRented = v.IsRented != null, 

                });
        
        }
    }
}
