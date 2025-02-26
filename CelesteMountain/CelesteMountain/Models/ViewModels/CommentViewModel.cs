using System.ComponentModel.DataAnnotations;

namespace CelesteMountain.Models
{
    public class CommentViewModel
    {
        public StoryPost Story {  get; set; }
        public Comment Comment { get; set; }
    }
}
