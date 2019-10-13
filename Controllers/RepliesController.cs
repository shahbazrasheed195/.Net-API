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
    public class RepliesController : ControllerBase
    {
        private readonly IReplyRepository _repo;
        private readonly IMapper _mapper;

        public RepliesController(IReplyRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpPost("AddReply")]
        public async Task<IActionResult> AddReply(ReplyFromUserDto replyFromUserDto)
        {
            var mappedReply = _mapper.Map<Reply>(replyFromUserDto);
            var response = await _repo.AddReply(mappedReply);
            if (response == true)
                return Ok(mappedReply);

            return BadRequest();

        }

    }
}