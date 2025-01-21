using CelesteMountain.Models.DomainModels;

namespace CelesteMountain.Models.Data
{
    public interface IStoryPostRepository
    {
        public StoryPost GetStoryById(int id);
        public List<StoryPost> GetAllStorys();
        public int NewStory(StoryPost model);
    }
}
