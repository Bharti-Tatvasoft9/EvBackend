using EVAPI.Data;
using EVAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EVAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {


        public EventController()
        {

        }

        [HttpPost("send")]
        public IActionResult SendEvent([FromBody] ChargingEvent payload)
        {

            return Ok(new { message = "Event received", payload });
        }
    }
}
