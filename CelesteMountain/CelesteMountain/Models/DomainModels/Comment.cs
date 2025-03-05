using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CelesteMountain.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Comment Requires Body Text")]
        [StringLength(750)]
        public String CommentText { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
        public AppUser Commenter { get; set; }
        public int StoryPostId { get; set; }  // FK to cause cascade delete
    }
}
