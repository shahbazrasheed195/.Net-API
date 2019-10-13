using System.Collections.Generic;
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
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _repo;
        private readonly IMapper _mapper;
        public PostsController(IPostRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpPost("AddPosts/")]
        public async Task<IActionResult> AddPost(PostForAddDto postForAddDto)
        {
            //   var userFromRepo = await _repo.GetUser(userId);

            var mappedPost = _mapper.Map<Post>(postForAddDto);

            var response = await _repo.AddPost(mappedPost);
            if (response == null)
                return BadRequest();

            return Ok(postForAddDto);
        }

        [HttpGet("GetPosts")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _repo.GetPosts();
            var postsToReturn = _mapper.Map<IEnumerable<PostsToReturnDto>>(posts);
            return Ok(postsToReturn);
        }

    }
}