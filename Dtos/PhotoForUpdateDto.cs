using System;

namespace DatingApp.API.Dtos
{
    public class PhotoForUpdateDto
    {
        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }
    }
}