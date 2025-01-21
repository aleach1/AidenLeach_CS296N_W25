using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelesteMountainTests.Fakes;
using CelesteMountain.Controllers;
using CelesteMountain.Models;
using Microsoft.Extensions.Logging;
using CelesteMountain.Data;

namespace CelesteMountainTests
{
    public class HomeControllerTests
    {
        IStoryPostRepository _repo = new FakeStoryPostRepository();
        private readonly ILogger<HomeController> _logger;
        HomeController controller;

        public HomeControllerTests()
        {
            controller = new HomeController(_repo, _logger);
        }

        [Fact]
        public void AddStoryPost()
        {
            // Arrange: Make a StoryPost to add
            var newPost = new StoryPost
            {
                Title = "I just started speedrunning, and strawberry jam is great for tech.",
                Topic = "Speedrunning",
                StoryYear = 2024,
                Text = "I never really knew how to do a lot of speedrunning tech, but the libraries in strawberry jam really helped me.",
                DatePosted = DateTime.Now

            };

            //Act: call post method on the controller
            var result = controller.PostStory(newPost);

            // Assert: Verify that StoryPost was added to repository
            var addedRepo = _repo.GetStoryById(newPost.Id);

            Assert.NotNull(addedRepo);
            Assert.Equal(addedRepo, newPost);
        }
    }
}
