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
        public  async Task<IActionResult> All([FromQuery] AllVehiclesQueryModel model)
        {
            var vehicles = await vehicleService.All(
                model.Category,
                model.Engine,
                model.Manufacturer,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.VehiclesPerPage);

            model.TotalVehiclesCount = vehicles.TotalVehicleCount;
            model.Vehicles = vehicles.Vehicles;

            model.Categories = await vehicleService.AllCategoriesNames();
            model.Engines = await vehicleService.AllEngineTypeNames();
            model.Manufacturers = await vehicleService.AllManufacturerNames();

            return  View(model);  
        }

        [HttpGet]
        public async Task <IActionResult> Mine()
        {
            var userId = User.Id();

            IEnumerable<VehicleServiceModel> model;



            if (await agentService.ExistsById(userId))
            {
                int agentId = await agentService.GetAgentId(userId) ?? 0;
                model = await vehicleService.AllVehiclesByAgentId(agentId);
            }

            else
            {
                model = await vehicleService.AllVehiclesByUserId(userId);
            }


            return  View(model);
        }
        [HttpGet]
        public async Task <IActionResult> Details (int id)
        {
            if (await vehicleService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }


            var model = await vehicleService.VehicleDetailsById(id);

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
        public async Task <IActionResult> Add(VehicleFormModel MODELL)
        {
            
            if (await vehicleService.CategoryExists(MODELL.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(MODELL.CategoryId), "test");

            }
            if (await vehicleService.EngineTypeExists(MODELL.EngineId) == false)
            {
                ModelState.AddModelError(nameof(MODELL.EngineId), "");
            }

            if (await vehicleService.ManufacturerExists(MODELL.ManufacturerId) == false)
            {
                ModelState.AddModelError(nameof(MODELL.ManufacturerId), "");
            }

            

            if (ModelState.IsValid == false)
            {
				MODELL.Categories = await vehicleService.AllCategories();
				MODELL.EngineType = await vehicleService.AllEngineTypes();
				MODELL.Manufacturer = await vehicleService.AllManufacturers();

                return View(MODELL);
            }

            int? agentId = await agentService.GetAgentId(User.Id());

            int newVehicleId = await vehicleService.Create(MODELL, agentId ?? 0);


            return RedirectToAction(nameof(Details), new { id = newVehicleId });

        }

        [HttpGet]
        public async Task <IActionResult> Edit (int id)
        {
            if (await vehicleService.ExistsAsync(id) == false)
            {
                return BadRequest();

            }

            if (await vehicleService.HasAgentWithId(id, User.Id()) == false)
            {
                return Unauthorized();
            }

                var model = await vehicleService.GetVehicleFormModelById(id);

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, VehicleFormModel MODELLL)
        {
            if (await vehicleService.ExistsAsync(id) == false)
            {
                return BadRequest();

            }

            if (await vehicleService.HasAgentWithId(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await vehicleService.CategoryExists(MODELLL.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(MODELLL.CategoryId), "ne baca");
            }

            if (ModelState.IsValid == false)
            {
				MODELLL.Categories = await vehicleService.AllCategories();
				MODELLL.Manufacturer = await vehicleService.AllManufacturers();
				MODELLL.EngineType = await vehicleService.AllEngineTypes();

                return View(MODELLL);
            }

            await vehicleService.Edit(id, MODELLL);

            return RedirectToAction(nameof(Details), new { id });
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
