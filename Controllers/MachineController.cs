using EVAPI.Data;
using EVAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EVAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachineController : ControllerBase
    {
        private readonly NeondbContext _context;

        public MachineController(NeondbContext context)
        {
            _context = context;
        }

        [HttpGet("evmachines")]
        public async Task<ActionResult<IEnumerable<Evmachine>>> GetMachines()
        {
            return await _context.Evmachines.ToListAsync();
        }

        [HttpGet("stations")]
        public async Task<ActionResult<IEnumerable<Station>>> GetStations()
        {
            return await _context.Stations.ToListAsync();
        }

        [HttpPost("savemachine")]
        public async Task<ActionResult<Evmachine>> SaveMachine([FromBody] Evmachine machine)
        {
            _context.Evmachines.Add(machine);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMachines), new { id = machine.Machineid }, machine);
        }

        [HttpPost("savestation")]
        public async Task<ActionResult<Evmachine>> SaveStation([FromBody] Station station)
        {
            _context.Stations.Add(station);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStations), new { id = station.Stationid }, station);
        }
    }
}
