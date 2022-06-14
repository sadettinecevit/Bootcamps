using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UpdatedMessageController : ControllerBase
    {
        readonly IUpdatedMessageRepository _updatedMessageRepository;
        public UpdatedMessageController(IUpdatedMessageRepository updatedMessageRepository)
        {
            _updatedMessageRepository = updatedMessageRepository;
        }

        [HttpGet("GetUpdatedMessagesById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            IActionResult retVal = null;
            UpdatedMessage result = await _updatedMessageRepository.GetByIdAsync(id);

            if (result == null)
            {
                retVal = BadRequest();
            }
            else
            {
                retVal = Ok(result);
            }

            return retVal;
        }

        [HttpGet("GetAllUpdatedMessages")]
        public async Task<IActionResult> GetAll()
        {
            IActionResult retVal = null;
            List<UpdatedMessage> result = await _updatedMessageRepository.GetAsync();

            if (result == null)
            {
                retVal = BadRequest();
            }
            else
            {
                retVal = Ok(result);
            }

            return retVal;
        }

        [HttpPost("AddUpdatedMessage")]
        public async Task<IActionResult> Add(UpdatedMessage updatedMessage)
        {
            UpdatedMessage result = await _updatedMessageRepository.Add(updatedMessage);

            IActionResult retVal = null;
            if (result != null)
            {
                retVal = Ok(result);
            }
            else
            {
                retVal = BadRequest(result);
            }

            return retVal;
        }

        [HttpPut("UpdateUpdatedMessage")]
        public async Task<IActionResult> Update(UpdatedMessage updatedMessage)
        {
            UpdatedMessage result = await _updatedMessageRepository.Update(updatedMessage);

            IActionResult retVal = null;
            if (result != null)
            {
                retVal = Ok(result);
            }
            else
            {
                retVal = BadRequest(result);
            }

            return retVal;
        }

        [HttpDelete("DeleteUpdatedMessage")]
        public async Task<IActionResult> Delete(UpdatedMessage updatedMessage)
        {
            UpdatedMessage result = await _updatedMessageRepository.Delete(updatedMessage);

            IActionResult retVal = null;
            if (result != null)
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
