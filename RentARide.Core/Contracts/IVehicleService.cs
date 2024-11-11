using RentARide.Core.Models.Home;
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
    }
}
