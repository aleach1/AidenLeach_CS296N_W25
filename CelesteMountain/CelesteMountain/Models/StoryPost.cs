namespace CelesteMountain.Models
{
    public class StoryPost
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Topic { get; set; }
        public int StoryYear { get; set; }
        public string? Text { get; set; }
        public string? Name { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
