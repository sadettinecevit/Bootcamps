using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using SocialNetwork.Application.Dto;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IDistributedCache _distributedCache;
        public UserController(IUserRepository userRepository,
            UserManager<User> userManager, IDistributedCache distributedCache)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _distributedCache = distributedCache;
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            IActionResult retVal = null;
            User result = await _userRepository.GetByIdAsync(id);

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

        [HttpGet("GetAllUsers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            IActionResult retVal = null;
            List<User> result = null;

            byte[] cachedBytes = _distributedCache.Get("GetAllUsers");

            if (cachedBytes == null)
            {
                result = await _userRepository.GetAsync();
            }
            else
            {
                string jsonData = Encoding.UTF8.GetString(cachedBytes);
                result = JsonSerializer.Deserialize<List<User>>(jsonData);
            }

            if (result == null)
            {
                retVal = BadRequest();
            }
            else
            {
                if (cachedBytes == null)
                {
                    string jsonUsers = JsonSerializer.Serialize(result);
                    _distributedCache.Set("GetAllUsers", Encoding.UTF8.GetBytes(jsonUsers));
                }
                retVal = Ok(result);
            }

            return retVal;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Add(UserDTO userDTO, string password)
        {
            IActionResult retVal = null;
            User user = new User()
            {
                Email = userDTO.Email,
                UserName = userDTO.UserName,
                Name = userDTO.Name,
                LastName = userDTO.Lastname
            };

            IdentityResult result = _userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                retVal = Ok(result);
            }
            else
            {
                retVal = BadRequest(result);
            }

            return retVal;
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update(User user)
        {
            User result = await _userRepository.Update(user);

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

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete(User user)
        {
            User result = await _userRepository.Delete(user);

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

