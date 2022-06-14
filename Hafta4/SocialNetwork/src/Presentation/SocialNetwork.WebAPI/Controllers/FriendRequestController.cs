using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendRequestController : ControllerBase
    {
        readonly IFriendRequestRepository _friendRequestRepository;
        readonly IFriendRepository _friendRepository;
        public FriendRequestController(IFriendRequestRepository friendRequestRepository, IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
            _friendRequestRepository = friendRequestRepository;
        }

        [HttpGet("GetFriendRequestById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            IActionResult retVal = null;
            FriendRequest result = await _friendRequestRepository.GetByIdAsync(id);

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

        [HttpGet("GetAllFrienRequest")]
        public async Task<IActionResult> GetAll()
        {
            IActionResult retVal = null;
            List<FriendRequest> result = await _friendRequestRepository.GetAsync();

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

        [HttpPost("AddFriendRequest")]
        public async Task<IActionResult> Add(FriendRequest friendRequest)
        {
            FriendRequest result = await _friendRequestRepository.Add(friendRequest);

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

        [HttpPut("UpdateFriendRequest")]
        public async Task<IActionResult> Update(FriendRequest friendRequest)
        {
            IActionResult retVal = null;
            Friend addResult = null;
            FriendRequest result = null;

            if (friendRequest.Response)
            {
                addResult = await _friendRepository.Add(
                    new Friend
                    {
                        FriendUser = friendRequest.FromUser,
                        User = friendRequest.ToUser,
                        TimeToBeFriend = friendRequest.ResponseTime
                    });

                addResult = await _friendRepository.Add(
                    new Friend
                    {
                        FriendUser = friendRequest.ToUser,
                        User = friendRequest.FromUser,
                        TimeToBeFriend = friendRequest.ResponseTime
                    });
            }

            if (addResult != null)
            {
                result = await _friendRequestRepository.Delete(friendRequest);
            }
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

        [HttpDelete("DeleteFriendRequest")]
        public async Task<IActionResult> Delete(FriendRequest friendRequest)
        {
            FriendRequest result = await _friendRequestRepository.Delete(friendRequest);

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
