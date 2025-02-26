using System.Runtime.Intrinsics.X86;
using System;
using CelesteMountain.Models;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace CelesteMountain.Data
{
    public class SeedData

    {
        public static void Seed(CelesteMountainContext context, IServiceProvider provider)
        {
            if (!context.StoryPosts.Any())  // this is to prevent adding duplicate data
            {
                var userManager = provider
                    .GetRequiredService<UserManager<AppUser>>();

                const string SECRET_PASSWORD = "Secret!123";
                AppUser rootUser = new AppUser { UserName = "rootUser" };
                var result = userManager.CreateAsync(rootUser, SECRET_PASSWORD);
                AppUser userTwo = new AppUser { UserName = "UserTwo" };
                result = userManager.CreateAsync(rootUser, SECRET_PASSWORD);
                AppUser userThree = new AppUser { UserName = "UserThree" };
                result = userManager.CreateAsync(rootUser, SECRET_PASSWORD);

                StoryPost storyPost = new StoryPost
                {
                    Title = "This is where to submit stories.",
                    Topic = "Story Posts",
                    StoryYear = 2024,
                    Text = "This is the area of the website that you can submit stories about Celeste, and it is formatted as seen.",
                    Poster = rootUser,
                    DatePosted = DateTime.Parse("11/29/24")
                };

                context.StoryPosts.Add(storyPost);  // queues up a review to be added to the DB

                Comment comment = new Comment
                {
                    CommentText = "This Is something I needed",
                    DatePosted = DateTime.Parse("11/30/24"),
                    Commenter = userTwo,
                    StoryId = 1
                };

                context.Comments.Add(comment);


                storyPost = new StoryPost
                {
                    Title = "I just started speedrunning, and strawberry jam is great for tech.",
                    Topic = "Speedrunning",
                    StoryYear = 2024,
                    Text = "I never really knew how to do a lot of speedrunning tech, but the libraries in strawberry jam really helped me.",
                    Poster = userTwo,
                    DatePosted = DateTime.Parse("11/30/24")
                };

                context.StoryPosts.Add(storyPost);

                comment = new Comment
                {
                    CommentText = "If you haven't, you should consider checking out some speedruns and try copying the pathing they use.",
                    DatePosted = DateTime.Parse("11/30/24"),
                    Commenter = userThree,
                    StoryId = 2
                };

                context.Comments.Add(comment);

                comment = new Comment
                {
                    CommentText = "Good luck on the speedrunning!",
                    DatePosted = DateTime.Parse("11/30/24"),
                    Commenter = rootUser,
                    StoryId = 2
                };

                context.Comments.Add(comment);

                storyPost = new StoryPost // need to change the contents of the other posts
                {
                    Title = "How many in game deaths is too many?",
                    Topic = "New Player",
                    StoryYear = 2024,
                    Text = "I recently started playing Celeste, and I have hundreds of deaths just from the first chapter. Is this normal, or am I just bad at platformers?",
                    Poster = userThree,
                    DatePosted = DateTime.Parse("11/30/24")
                };

                context.StoryPosts.Add(storyPost);


                context.SaveChanges(); // stores all the reviews in the DB



            }


        }

    }

}

