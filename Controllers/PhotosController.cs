using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        public PhotosController(IDatingRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddPhoto(int userId, PhotoForAddDto photoForAddDto)
        {
            var userFromRepo = await _repo.GetUser(userId);
            var photo = _mapper.Map<Photo>(photoForAddDto);

            userFromRepo.Photos.Add(photo);
            if (await _repo.SaveAll())
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photo = await _repo.GetPhoto(id);
            if (photo == null)
            {
                return NotFound();
            }

            return Ok(photo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var photoFromRepo = await _repo.GetPhoto(id);
            var response = await _repo.DeletePhoto(photoFromRepo);
            if (response == false)
                return BadRequest();

            return Ok(photoFromRepo);

        }

        //[HttpPut("{id}")]

        // public async Task<IActionResult> UpdatePhoto(int userId, int id, PhotoForUpdateDto photoForUpdateDto)
        // {
        //     var photo = await _repo.GetPhoto(id);

        //     var photoForUpdate = _mapper.Map<Photo>(photoForUpdateDto);
        //     photoForUpdate.UserId = userId;
        //     var response = await _repo.UpdatePhoto(id, photoForUpdate);
        //     if (response == false)
        //     {
        //         return BadRequest();
        //     }
        //     return Ok(photoForUpdate);
        // }

    }
}