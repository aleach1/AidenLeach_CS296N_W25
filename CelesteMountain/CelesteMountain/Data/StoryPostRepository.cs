using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using CelesteMountain.Models;

namespace CelesteMountain.Data
{
    public class StoryPostRepository : IStoryPostRepository
    {
        private CelesteMountainContext _context;

        public StoryPostRepository(CelesteMountainContext appDbContext)
        {
            _context = appDbContext;
        }

        //return all storyposts from repository
        public List<StoryPost> GetAllStorys()
        {
            var storys = _context.StoryPosts
              .ToList();
            return storys;
        }

        //return a storypost with a specific id
        public StoryPost GetStoryById(int id)
        {
            var story = _context.StoryPosts
              .Where(story => story.Id == id)
              .SingleOrDefault();
            return story;
        }

        //adds a story to the database and returns a positive value if succussful
        public int NewStory(StoryPost model)
        {
            model.DatePosted = DateTime.Now;
            _context.StoryPosts.Add(model);
            return _context.SaveChanges();
        }
    }
}
