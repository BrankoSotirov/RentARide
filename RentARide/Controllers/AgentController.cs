using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentARide.Attributes;
using RentARide.Core.Contracts;
using RentARide.Core.Models.Agent;
using RentARide.Extensions;

namespace RentARide.Controllers
{

	public class AgentController : BaseController
	{

		private readonly IAgentService agentService;

		public AgentController(IAgentService _agentService)
		{

			agentService = _agentService;	
		}
		[HttpGet]
		[NotAnAgent]
		public async Task <IActionResult> Become()
		{

			if (await agentService.ExistsById(User.Id()))
			{
				return BadRequest();
			}

			var model = new BecomeAgentFormModel();

			return View(model);
		

		}
		[HttpPost]
		[NotAnAgent]
		public async Task <IActionResult> Become(BecomeAgentFormModel model)
		{
			if (await agentService.UserWithPhoneNumberExists(model.PhoneNumber))
			{
				ModelState.AddModelError(nameof(model.PhoneNumber), "");

			}

			if (await agentService.UserHasRent(User.Id())) {

				ModelState.AddModelError("Error", "") ;

			}

			if (ModelState.IsValid == false) {
			
				return View(model);
			}

			await agentService.Create(User.Id(), model.PhoneNumber);

			return RedirectToAction(nameof(VehicleController.All), "Vehicle");
		}

	}
}
