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
        private readonly AppDbContext _context;

        public MachineController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EVMachine>>> GetMachines()
        {
            return await _context.Machines.ToListAsync();
        }

    }
}
