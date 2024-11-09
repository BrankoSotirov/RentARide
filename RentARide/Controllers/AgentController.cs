﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentARide.Core.Models.Agent;

namespace RentARide.Controllers
{
	[Authorize]
	public class AgentController : Controller
	{
		[HttpGet]
		public async Task <IActionResult> Become()
		{
			var model = new BecomeAgentFormModel();


			return View(model);
		}
		[HttpPost]

		public async Task <IActionResult> Become(BecomeAgentFormModel model)
		{

			return RedirectToAction(nameof(VehicleController.All), "Vehicle");
		}

	}
}