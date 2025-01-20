using CelesteMountain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CelesteMountain.Controllers
{
    public class SpeedController : Controller
    {

        private readonly ILogger<SpeedController> _logger;

        public SpeedController(ILogger<SpeedController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
