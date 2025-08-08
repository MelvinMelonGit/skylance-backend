using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using skylance_backend.Attributes;
using skylance_backend.Data;
using skylance_backend.Models;
using skylance_backend.Services;
namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OverbookingController : Controller
    {
        private readonly SkylanceDbContext _db;
        private readonly CompensationService _compensation;

        public OverbookingController(SkylanceDbContext db,CompensationService compensation)
        {
            _db = db;
            _compensation = compensation;   
        }
        [HttpGet("overbooking")]
        public async Task<IActionResult> GetOverbookingDetail([FromQuery] string flightBookingDetailId)
        {
            var flightBookingDetail = await _db.FlightBookingDetails
                .Include(b => b.FlightDetail)
                .Include(b => b.BookingDetail)
                    .ThenInclude(x => x.AppUser)
                .FirstOrDefaultAsync(b => b.Id == flightBookingDetailId);
            
            if (flightBookingDetail == null)
            {
                return NotFound();
            }
            var distance = flightBookingDetail.FlightDetail.Distance;
            double compensation = CalculateCompensation(flightBookingDetail.FlightDetail.Distance);
         
            var overbooking = new OverbookingDetail
            {
                Id = Guid.NewGuid().ToString(),
                OldFlightBookingDetail = flightBookingDetail,
                OldFlightBookingDetailId = flightBookingDetail.Id,
                NewFlightBookingDetail = null,
                NewFlightBookingDetailId = null, 
                IsRebooking = false,
                FinalCompensationAmount =await  _compensation.CalculateCompensationAsync(flightBookingDetailId)
            };

            await _db.OverbookingDetails.AddAsync(overbooking);
            await _db.SaveChangesAsync();

            return Ok(new
            {
                OverbookingDetailId = overbooking.Id,
                FinalCompensationAmount = overbooking.FinalCompensationAmount,
                User = new
                {
                    UserName = flightBookingDetail.BookingDetail.AppUser.FirstName
                }
            });
        }
        private double CalculateCompensation(double distance)
        {
            var compensation = 0;
            if (distance <= 1500)
            {
                compensation = 380;
            }
            else if (distance <= 3500)
            {
                compensation = 600;
            }
            else
            {
                compensation = 900;
            }
            return compensation;
        }
    }
}