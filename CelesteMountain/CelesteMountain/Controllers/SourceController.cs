using CelesteMountain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CelesteMountain.Controllers
{
    public class SourceController : Controller
    {
        private readonly ILogger<SourceController> _logger;

        public SourceController(ILogger<SourceController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FanSites()
        {
            return View();
        }
        public IActionResult News()
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
