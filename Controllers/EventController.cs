using EVAPI.Data;
using EVAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EVAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly NeondbContext _context;
        private readonly EventHubService _hub;
        public EventController(NeondbContext context, EventHubService hub)
        {
            _context = context;
            _hub = hub;
        }


        [HttpPost("send")]
        public async Task<IActionResult> SendEvent([FromBody] ChargingEvent payload)
        {
           
            try
            {
                string json = JsonSerializer.Serialize(payload);
                await _hub.SendEventAsync(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(new { message = "Event logged to DB" });
        }
    }
}
