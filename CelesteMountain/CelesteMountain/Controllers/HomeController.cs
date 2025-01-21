using CelesteMountain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CelesteMountain.Data;

namespace CelesteMountain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IStoryPostRepository _repo;

        public HomeController(IStoryPostRepository repo, ILogger<HomeController> logger)
        {
            _repo = repo;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Stories()
        {
            var posts = _repo.GetAllStorys(); // For fetching posts and ratings from the database
            return View(posts);
        }

        [HttpGet]
        public IActionResult Filter(string poster, string date)
        {
            var storys = _repo.GetAllStorys()
                .Where(s => poster == null || s.Name == poster)
                .Where(s => date == null || DateOnly.FromDateTime(s.DatePosted) == DateOnly.Parse(date))
                .ToList();

            return View("Stories", storys);
        }

        public IActionResult PostStory()
        {

            return View();
        }

        [HttpPost]
        public IActionResult PostStory(StoryPost newStory)
        {
            if (_repo.NewStory(newStory) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error saving the review.";
                return View();
            }
        }

        public IActionResult Privacy()
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
