using Microsoft.AspNetCore.Mvc;

namespace CelesteMountain.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
