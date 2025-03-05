using CelesteMountain.Models;

namespace CelesteMountain.Data
{
    public interface IStoryPostRepository
    {
        public StoryPost GetStoryById(int id);
        public List<StoryPost> GetAllStorys();
        public Task<int> NewStoryAsync(StoryPost model);
        public Task<int> DeleteStorysAsync(AppUser appUser);
        public Task<int> NewCommentAsync(Comment model);
    }
}
