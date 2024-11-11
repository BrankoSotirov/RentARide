using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentARide.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

      
    }
}
