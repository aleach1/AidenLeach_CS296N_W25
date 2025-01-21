using CelesteMountain.Models;

namespace CelesteMountain.Data
{
    public interface IStoryPostRepository
    {
        public StoryPost GetStoryById(int id);
        public List<StoryPost> GetAllStorys();
        public int NewStory(StoryPost model);
    }
}
