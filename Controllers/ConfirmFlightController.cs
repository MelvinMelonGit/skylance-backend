using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;
using skylance_backend.Models;

namespace skylance_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmFlightController : ControllerBase
    {
        private readonly SkylanceDbContext _context;

        public ConfirmFlightController(SkylanceDbContext context)
        {
            _context = context;
        }


        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetAppUserDetail(string id)
        {
            var appUserDetail = await _context.AppUsers
                .Include(f => f.Nationality)
                .Include(f => f.MobileCode)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (appUserDetail == null)
            {
                return NotFound();
            }

            return appUserDetail;
        }
    }
}
