using System;
using DatingApp.API.Models;

namespace DatingApp.API.Dtos
{
    public class CommentToUpdateDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        //  public Post Post { get; set; }

        public int PostId { get; set; }
    }
}