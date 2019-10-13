using System;

namespace DatingApp.API.Dtos
{
    public class ReplyFromUserDto
    {


        public string Description { get; set; }


        public DateTime CreatedAt { get; set; }

        public int CommentId { get; set; }
    }
}