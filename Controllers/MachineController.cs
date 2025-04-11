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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evmachine>>> GetMachines()
        {
            return await _context.Evmachines.ToListAsync();
        }

    }
}
