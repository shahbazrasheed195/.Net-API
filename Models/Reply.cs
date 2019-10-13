using System;

namespace DatingApp.API.Models
{
    public class Reply
    {
        public int Id { get; set; }

        public string Description { get; set; }


        public DateTime CreatedAt { get; set; }

        public Comment Comment { get; set; }

        public int CommentId { get; set; }

        
    }
}