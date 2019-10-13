using System;

namespace DatingApp.API.Dtos
{
    public class PostCollectionDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateAt { get; set; }
    }
}