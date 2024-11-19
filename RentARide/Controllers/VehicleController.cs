using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RentARide.Attributes;
using RentARide.Core.Contracts;
using RentARide.Core.Models.Vehicle;
using RentARide.Extensions;

namespace RentARide.Controllers
{
    [Authorize]
    public class VehicleController : BaseController
    {
        private readonly IVehicleService vehicleService;
        private readonly IAgentService agentService;

        public VehicleController(IVehicleService _vehicleService, IAgentService _agentService)
        {
            vehicleService = _vehicleService;
            agentService = _agentService;
        }

        [AllowAnonymous]
        [HttpGet]
        public  async Task<IActionResult> All()
        {
            var model = new AllVehiclesQueryModel();
            return  View(model);  
        }

        [HttpGet]
        public async Task <IActionResult> Mine()
        {
            var model = new AllVehiclesQueryModel();

            return  View(model);
        }
        [HttpGet]
        public async Task <IActionResult> Details (int id)
        {

            var model = new VehicleDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        [MustBeAgent]
        public async Task <IActionResult> Add()
        {
       
            var model = new VehicleFormModel()
            {
                Categories = await vehicleService.AllCategories(),
               EngineType = await vehicleService.AllEngineTypes(),
                Manufacturer = await vehicleService.AllManufacturers()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeAgent]
        public async Task <IActionResult> Add(VehicleFormModel model)
        {
            if (await vehicleService.CategoryExists(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "");

            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await vehicleService.AllCategories();
                model.EngineType = await vehicleService.AllEngineTypes();
                model.Manufacturer = await vehicleService.AllManufacturers();

                return View(model);
            }

            int? agentId = await agentService.GetAgentId(User.Id());

            int newHouseId = await vehicleService.Create(model, agentId ?? 0);


            return RedirectToAction(nameof(Details), new { id = newHouseId });

        }

        [HttpGet]
        public async Task <IActionResult> Edit (int id)
        {

            var model = new VehicleFormModel();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, VehicleFormModel model)
        {
			return RedirectToAction(nameof(Details), new { id = "1" });
		}


		public async Task<IActionResult> Delete(int id)
		{

			var model = new VehicleDetailsViewModel();

			return View(model);
		}

		[HttpPost]

		public async Task<IActionResult> Delete(VehicleDetailsViewModel model)
		{
			return RedirectToAction(nameof(All));
		}


        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }


		[HttpPost]
		public async Task<IActionResult> Leave(int id)
		{
			return RedirectToAction(nameof(Mine));
		}


	}
}
