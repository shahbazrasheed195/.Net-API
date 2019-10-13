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
    public class CommentsController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ICommentRepository _repo;
        public CommentsController(ICommentRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpPost("AddComment/")]
        public async Task<IActionResult> AddComment(int userId, int postId, CommentToAddDto commentToAddDto)
        {
            var post = await _repo.GetPost(postId, userId);
            var mappedPost = _mapper.Map<Comment>(commentToAddDto);
            post.Comments.Add(mappedPost);

            if (await _repo.SaveAll())
                return Ok(post.Comments);

            return BadRequest();
        }

        [HttpPut("UpdatePost")]
        public async Task<IActionResult> UpdatePost(CommentToUpdateDto commentToUpdate)
        {
            var comment = await _repo.GetComment(commentToUpdate.Id, commentToUpdate.PostId);
            var mappedComment = _mapper.Map<Comment>(commentToUpdate);
            _repo.UpdateComment(mappedComment);
            if (await _repo.SaveAll())
                return Ok(comment);
            return BadRequest();
        }
    }


}
