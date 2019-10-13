using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }

        public ICollection<Reply> Replies { get; set; }

        public Comment()
        {
            Replies = new List<Reply>();
        }


    }
}