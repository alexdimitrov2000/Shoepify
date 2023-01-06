using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shoepify.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            // todo: notify the user he has no access
            return this.RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
