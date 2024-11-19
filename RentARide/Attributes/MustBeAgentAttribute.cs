using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RentARide.Core.Contracts;
using RentARide.Extensions;
using RentARide.Controllers;

namespace RentARide.Attributes
{
    public class MustBeAgentAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IAgentService? agentService = context.HttpContext.RequestServices.GetService<IAgentService>();

            if (agentService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            if (agentService != null &&
                agentService.ExistsById(context.HttpContext.User.Id()).Result == false)
            {

                context.Result = new RedirectToActionResult(nameof(AgentController.Become), "Agent", null);
            }
        }
    }
}
