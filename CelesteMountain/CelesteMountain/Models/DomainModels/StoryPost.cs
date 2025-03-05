using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CelesteMountain.Models
{
    public class StoryPost
    {
        [Key]
        public int StoryPostId { get; set; }

        [Required(ErrorMessage = "Post Requires a Title")]
        [StringLength(200)]
        public string Title { get; set; }
        public string? Topic { get; set; }

        [Range(2018, 2025)]
        public int StoryYear { get; set; }

        [Required(ErrorMessage = "Post Requires Body Text")]
        [StringLength(750)]
        public string? Text { get; set; }
        public AppUser? Poster { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
