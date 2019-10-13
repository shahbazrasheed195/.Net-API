using System;
using System.Collections.Generic;
using DatingApp.API.Models;

namespace DatingApp.API.Dtos
{
    public class PostsToReturnDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateAt { get; set; }

        public int UserId { get; set; }


    }
}