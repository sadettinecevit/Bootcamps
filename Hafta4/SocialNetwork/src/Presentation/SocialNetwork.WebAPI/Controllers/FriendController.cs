using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendController : ControllerBase
    {
        readonly IFriendRepository _friendRepository;
        public FriendController(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        [HttpGet("GetFriendById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            IActionResult retVal = null;
            Friend result = await _friendRepository.GetByIdAsync(id);

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

        [HttpGet("GetAllFriend")]
        public async Task<IActionResult> GetAll()
        {
            IActionResult retVal = null;
            List<Friend> result = await _friendRepository.GetAsync();

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

        [HttpPost("AddFriend")]
        public async Task<IActionResult> Add(Friend friend)
        {
            Friend result = await _friendRepository.Add(friend);

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

        [HttpPut("UpdateFriend")]
        public async Task<IActionResult> Update(Friend friend)
        {
            Friend result = await _friendRepository.Update(friend);

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

        [HttpDelete("DeleteFriend")]
        public async Task<IActionResult> Delete(Friend friend)
        {
            Friend result = await _friendRepository.Delete(friend);

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
