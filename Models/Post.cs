using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateAt { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public List<Comment> Comments { get; set; }

        public Post()
        {
            Comments = new List<Comment>();
        }
    }
}