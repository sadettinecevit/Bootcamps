using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SadettinEcevitOdevHafta2_1.Extensions;

namespace SadettinEcevitOdevHafta2_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatetimeExtensionsController : ControllerBase
    {
        [HttpGet("ago")]
        public IActionResult Get(string date)
        {
            IActionResult retVal;

            DateTime tarih;
            if (DateTime.TryParse(date, out tarih))
            {
                retVal = Ok(Convert.ToDateTime(date).Ago());
            }
            else
            {
                retVal = BadRequest("Geçersiz bir tarih girildi.");
            }
            return retVal;
        }
    }
}
