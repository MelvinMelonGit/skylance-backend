using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;
using skylance_backend.Enum;
using skylance_backend.Models;
using skylance_backend.Services;

namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardingPassController : Controller
    {
        private readonly SkylanceDbContext _context;
        private readonly ITripService _tripService;
        public BoardingPassController(ITripService tripService, SkylanceDbContext context)
        {
            _tripService = tripService;
            _context = context;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllBoardingPassboards(string userId)
        {


            var checkInIds = await _context.CheckInDetails
                             .Where(c => c.AppUser.Id == userId)
                             .Select(c => c.Id)
                             .ToListAsync();


            if (!checkInIds.Any())
            {
                return NotFound(new
                {
                    message = "No boardingpass found for this user"
                });
            }
            var boardingPasses = new List<object>();
            foreach (var checkInId in checkInIds)
            {
                var pass = await _tripService.GetBoardingPass(checkInId);
                if (pass != null)
                {
                    boardingPasses.Add(pass);
                }
            }

            if (!boardingPasses.Any())
            {
                return NotFound(new { status = "NotFound", message = "No boarding passes found" });
            }

            return Ok(new
            {
                status = "Success",
                count = boardingPasses.Count,
                boardingPasses = boardingPasses
            });
        }
        [HttpGet("{checkInId}/boardingPass")]
        public async Task<IActionResult> GetBoardingPass(string checkInId)
        {
            if (string.IsNullOrEmpty(checkInId))
            {
                return new JsonResult(new
                {
                    status = "Invalid"
                });
            }

            var boardingPass = await _tripService.GetBoardingPass(checkInId);

            if (boardingPass == null)
            {
                return new JsonResult(new
                {
                    status = "NotFound"
                }); // Could also redirect to an error page
            }

            return new JsonResult(boardingPass);
        }
    }

}