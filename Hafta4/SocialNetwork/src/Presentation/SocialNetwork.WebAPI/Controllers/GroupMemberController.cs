using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupMemberController : ControllerBase
    {
        readonly IGroupMemberRepository _groupMemberRepository;
        public GroupMemberController(IGroupMemberRepository groupMemberRepository)
        {
            _groupMemberRepository = groupMemberRepository;
        }

        [HttpGet("GetGroupMemberById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            IActionResult retVal = null;
            GroupMember result = await _groupMemberRepository.GetByIdAsync(id);

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

        [HttpGet("GetAllGroupMember")]
        public async Task<IActionResult> GetAll()
        {
            IActionResult retVal = null;
            List<GroupMember> result = await _groupMemberRepository.GetAsync();

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

        [HttpPost("AddGroupMember")]
        public async Task<IActionResult> Add(GroupMember groupMember)
        {
            GroupMember result = await _groupMemberRepository.Add(groupMember);

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

        [HttpPut("UpdateGroupMember")]
        public async Task<IActionResult> Update(GroupMember groupMember)
        {
            GroupMember result = await _groupMemberRepository.Update(groupMember);

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

        [HttpDelete("DeleteGroupMember")]
        public async Task<IActionResult> Delete(GroupMember groupMember)
        {
            GroupMember result = await _groupMemberRepository.Delete(groupMember);

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
