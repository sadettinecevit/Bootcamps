using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository) => _commentRepository = commentRepository;

        [HttpGet("GetAllComment")]
        public async Task<IActionResult> GetAll()
        {
            IActionResult retVal = null;
            List<Comment>? result = await _commentRepository.GetAsync();

            if(result == null)
            {
                retVal = BadRequest();
            }
            else
            {
                retVal = Ok(result);
            }

            return retVal;
        }

        [HttpGet("GetCommentById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            IActionResult retVal = null;
            Comment? result = await _commentRepository.GetByIdAsync(id);

            if(result == null)
            {
                retVal = BadRequest();
            }
            else
            {
                retVal = Ok(result);
            }

            return retVal;
        }

        [HttpPost("AddComment")]
        public async Task<IActionResult> Add(Comment comment)
        {
            Comment result = await _commentRepository.Add(comment);

            IActionResult retVal = null;
            if(result != null)
            {
                retVal = Ok(result);
            }
            else
            {
                retVal = BadRequest(result);
            }

            return retVal;
        }
                
        [HttpPut("UpdateComment")]
        public async Task<IActionResult> Update(Comment comment)
        {
            Comment result = await _commentRepository.Update(comment);

            IActionResult retVal = null;
            if(result != null)
            {
                retVal = Ok(result);
            }
            else
            {
                retVal = BadRequest(result);
            }

            return retVal;
        }
                
        [HttpDelete("DeleteComment")]
        public async Task<IActionResult> Delete(Comment comment)
        {
            Comment result = await _commentRepository.Delete(comment);

            IActionResult retVal = null;
            if(result != null)
            {
                retVal = Ok(result);
            }
            else
            {
                retVal = BadRequest(result);
            }

            return retVal;
        }

        
    }
}
