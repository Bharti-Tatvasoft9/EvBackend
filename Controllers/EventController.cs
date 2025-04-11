using EVAPI.Data;
using EVAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EVAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly NeondbContext _context;

        public EventController(NeondbContext context)
        {
            _context = context;
        }


        [HttpPost("send")]
        public async Task<IActionResult> SendEvent([FromBody] ChargingEvent payload)
        {
            _context.Chargingevents.Add(payload);
            try
            {

            await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(new { message = "Event logged to DB" });
        }
    }
}
