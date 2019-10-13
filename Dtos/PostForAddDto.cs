using System;

namespace DatingApp.API.Dtos
{
    public class PostForAddDto
    {
        public string Name { get; set; }

        public DateTime CreateAt { get; set; }

        public int UserId { get; set; }

    }
}