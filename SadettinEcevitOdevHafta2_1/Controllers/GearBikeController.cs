using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SadettinEcevitOdevHafta2_1.SOLID;

namespace SadettinEcevitOdevHafta2_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearBikeController : ControllerBase
    {
        private IBicycle _bicycle { get; }

        public GearBikeController(IEnumerable<IBicycle> bicycle)
        {
            _bicycle = bicycle.SingleOrDefault(I => I.GetType() == typeof(GearBike));
        }

        [HttpGet(Name ="GetGearBike")]
        public IActionResult Get()
        {
            IActionResult retVal = Ok(_bicycle.GetType().ToString());

            return retVal;
        }

    }
}
