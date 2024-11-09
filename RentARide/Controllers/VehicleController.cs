using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RentARide.Core.Models.Vehicle;

namespace RentARide.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
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
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Add(VehicleFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });

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
