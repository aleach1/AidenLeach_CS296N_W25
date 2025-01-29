using CelesteMountain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelesteMountain.Data;
using Microsoft.EntityFrameworkCore;

namespace CelesteMountainTests.Fakes
{
    public class FakeStoryPostRepository : IStoryPostRepository
    {
        private List<StoryPost> _storyPosts = new List<StoryPost>();

        

        //return all storyposts from repository
        public List<StoryPost> GetAllStorys()
        {
            return _storyPosts;
        }

        //return a storypost with a specific id
        public StoryPost GetStoryById(int id)
        {
            StoryPost storyPost = _storyPosts.Find(s => s.Id == id);
            return storyPost;
        }

        //adds a story to the database and returns a positive value if succussful
        public int NewStory(StoryPost model)
        {
            int status = 0;
            if (model != null)
            {
                model.Id = _storyPosts.Count + 1;
                _storyPosts.Add(model);
                status = 1;
            }
            return status;
        }
        public int DeleteStorys(AppUser appUser)
        {
            //Need to make fake deletestorys
            return 0;
        }
    }
}
