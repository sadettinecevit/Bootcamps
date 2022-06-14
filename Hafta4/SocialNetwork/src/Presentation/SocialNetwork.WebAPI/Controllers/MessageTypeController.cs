using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using SocialNetwork.Application.Interfaces.Repositories;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [Authorize]
    public class MessageTypeController : ControllerBase
    {
        private readonly IMessageTypeRepository _messageTypeRepository;
        private readonly IMemoryCache _memoryCache;
        public MessageTypeController(IMessageTypeRepository messageTypeRepository, 
            IMemoryCache memoryCache)
        {
            _messageTypeRepository = messageTypeRepository;
            _memoryCache = memoryCache;
        }

        [HttpGet("GetMessageTypeById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            IActionResult retVal = null;
            MessageType result = await _messageTypeRepository.GetByIdAsync(id);

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

        [HttpGet("GetAllMessageType")]
        public async Task<IActionResult> GetAll()
        {
            List<MessageType> result = null;
            IActionResult retVal = null;

            if (!_memoryCache.TryGetValue("messageType", out result))
            {
                result = await _messageTypeRepository.GetAsync();

                if (result == null)
                {
                    retVal = BadRequest();
                }
                else
                {
                    retVal = Ok(result);

                    MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions();
                    memoryCacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                    memoryCacheEntryOptions.SlidingExpiration = TimeSpan.FromMinutes(30);
                    memoryCacheEntryOptions.Priority = CacheItemPriority.Normal;

                    _memoryCache.Set("messageType", result, memoryCacheEntryOptions);
                }
            }
            else
            {
                retVal = Ok(result);
            }
            return retVal;
        }

        [HttpPost("AddMessageType")]
        public async Task<IActionResult> Add(MessageType messageType)
        {
            MessageType result = await _messageTypeRepository.Add(messageType);

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

        [HttpPut("UpdateMessageType")]
        public async Task<IActionResult> Update(MessageType messageType)
        {
            MessageType result = await _messageTypeRepository.Update(messageType);

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

        [HttpDelete("DeleteMessageType")]
        public async Task<IActionResult> Delete(MessageType messageType)
        {
            MessageType result = await _messageTypeRepository.Delete(messageType);

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
