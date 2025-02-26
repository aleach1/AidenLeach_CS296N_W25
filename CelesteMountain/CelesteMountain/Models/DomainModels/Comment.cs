using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CelesteMountain.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public String CommentText { get; set; }
        public DateTime DatePosted { get; set; }
        public AppUser Commenter { get; set; }
        public int StoryId { get; set; }  // FK to cause cascade delete
    }
}
