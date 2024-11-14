﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

		public async Task <IActionResult> Become(BecomeAgentFormModel model)
		{

			return RedirectToAction(nameof(VehicleController.All), "Vehicle");
		}

	}
}
