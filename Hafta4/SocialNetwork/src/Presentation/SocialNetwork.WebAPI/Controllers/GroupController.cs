using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        readonly IGroupRepository _groupRepository;
        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [HttpGet("GetGroupById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            IActionResult retVal = null;
            Group result = await _groupRepository.GetByIdAsync(id);

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

        [HttpGet("GetAllGroup")]
        public async Task<IActionResult> GetAll()
        {
            IActionResult retVal = null;
            List<Group> result = await _groupRepository.GetAsync();

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

        [HttpPost("AddGroup")]
        public async Task<IActionResult> Add(Group group)
        {
            Group result = await _groupRepository.Add(group);

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

        [HttpPut("UpdateGroup")]
        public async Task<IActionResult> Update(Group group)
        {
            Group result = await _groupRepository.Update(group);

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

        [HttpDelete("DeleteGroup")]
        public async Task<IActionResult> Delete(Group group)
        {
            Group result = await _groupRepository.Delete(group);

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
