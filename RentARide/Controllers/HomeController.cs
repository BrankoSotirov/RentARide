using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentARide.Core.Contracts;
using RentARide.Core.Models.Home;
using RentARide.Models;
using System.Diagnostics;

namespace RentARide.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleService vehicleService;

        public HomeController(
            ILogger<HomeController> logger,
			IVehicleService _vehicleservice)
        {
            _logger = logger;
           vehicleService = _vehicleservice;
            
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await vehicleService.LastThreeVehicles();

            return View(model);
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
