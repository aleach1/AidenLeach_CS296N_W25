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
                .Include(story => story.Poster)
              .ToList();
            return storys;
        }

        //return a storypost with a specific id
        public StoryPost GetStoryById(int id)
        {
            var story = _context.StoryPosts
              .Where(story => story.Id == id)
              .Include(story => story.Poster)
              .SingleOrDefault();
            return story;
        }

        //adds a story to the database and returns a positive value if succussful
        public async Task<int> NewStoryAsync(StoryPost model)
        {
            model.DatePosted = DateTime.Now;
            _context.StoryPosts.Add(model);
            Task<int> task = _context.SaveChangesAsync();
            int result = await task;
            return result;
        }

        // deletes all stories tied to a user

        public async Task<int> DeleteStorysAsync(AppUser appUser)
        {
            var story = _context.StoryPosts
              .Where(story => story.Poster == appUser)
              .Include(story => story.Poster)
              .ToList();
            _context.StoryPosts.RemoveRange(story);
            Task<int> task = _context.SaveChangesAsync();
            int result = await task;
            return result;
        }
    }
}
