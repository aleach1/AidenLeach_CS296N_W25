using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CelesteMountain.Models
{
    public class StoryPost
    {
        [Key]
        public int StoryPostId { get; set; }
        public string? Title { get; set; }
        public string? Topic { get; set; }
        public int StoryYear { get; set; }
        public string? Text { get; set; }
        public AppUser? Poster { get; set; }
        public DateTime DatePosted { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
