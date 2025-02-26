using CelesteMountain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CelesteMountain.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace CelesteMountain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        IStoryPostRepository _repo;

        public HomeController(IStoryPostRepository repo, ILogger<HomeController> logger, UserManager<AppUser> usrMngr,
            SignInManager<AppUser> signInMngr)
        {
            _repo = repo;
            _logger = logger;
            userManager = usrMngr;
            signInManager = signInMngr;
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
            StoryViewModel StoryVM = new StoryViewModel { Stories = posts };
            return View(StoryVM);
        }

        [HttpGet]
        public IActionResult Filter(string poster, string date)
        {
            var storys = _repo.GetAllStorys()
                .Where(s => poster == null || s.Poster.UserName == poster)
                .Where(s => date == null || DateOnly.FromDateTime(s.DatePosted) == DateOnly.Parse(date))
                .ToList();

            return View("Stories", storys);
        }

        [Authorize]
        public IActionResult PostStory()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostStory(StoryPost newStory)
        {
            // send user to login if not logged in
            if (!signInManager.IsSignedIn(User))
            {
                var returnURL = Request.GetEncodedUrl();
                return RedirectToAction("Login", "Account", returnURL);
            }

            // get appuser for current user
            newStory.Poster = userManager.GetUserAsync(User).Result;
            if (userManager != null)
            {
                newStory.Poster = await userManager.GetUserAsync(User);
            }
            if (await _repo.NewStoryAsync(newStory) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error saving the review.";
                return View();
            }
        }

        [Authorize]
        public IActionResult PostComment(StoryViewModel StoryVM)
        {
            CommentViewModel CommentVM = new CommentViewModel{Story = StoryVM.Story};
            return View(CommentVM);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostComment(CommentViewModel commentVM)
        {
            Comment newComment = commentVM.Comment;
            // send user to login if not logged in
            if (!signInManager.IsSignedIn(User))
            {
                var returnURL = Request.GetEncodedUrl();
                return RedirectToAction("Login", "Account", returnURL);
            }

            // get appuser for current user
            newComment.Commenter = userManager.GetUserAsync(User).Result;
            if (userManager != null)
            {
                newComment.Commenter = await userManager.GetUserAsync(User);
            }
            if (await _repo.NewCommentAsync(newComment) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error saving the comment.";
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
