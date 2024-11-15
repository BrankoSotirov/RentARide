using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentARide.Core.Contracts;
using RentARide.Extensions;

namespace RentARide.Attributes
{
    public class NotAnAgentAttribute : ActionFilterAttribute
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
                agentService.ExistsById(context.HttpContext.User.Id()).Result)
            {

                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            
            }
        }
    }
}
