using Microsoft.AspNetCore.Mvc;
using skylance_backend.Data;
using skylance_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OverbookingController : Controller
    {
        private readonly SkylanceDbContext _db;

        public OverbookingController(SkylanceDbContext db)
        {
            _db = db;
        }
        [HttpGet("overbooking")]
        public IActionResult GetOverbookingDetail(string flightBookingDetailId)
        {
            var flightBookingDetail = _db.FlightBookingDetails
                .Include(b => b.FlightDetail)
                .Include(b => b.BookingDetail)
                    .ThenInclude(x => x.AppUser)
                .FirstOrDefault(b => b.Id == flightBookingDetailId);


            if (flightBookingDetail == null)
            {
                return NotFound();
            }
            double compensation = CalculateCompensation(flightBookingDetail.FlightDetail.Distance);
            var overbooking = new OverbookingDetail
            {
                Id = Guid.NewGuid().ToString(),

                OldBookingFlightDetailId = flightBookingDetail.Id,
                OldBookingFlightDetail = flightBookingDetail,
                NewBookingFlightDetailId = null,
                NewBookingFlightDetail = null,
                IsRebooking = false,
                FinalCompensationAmount = compensation
            };

            _db.OverbookingDetails.Add(overbooking);
            _db.SaveChanges();

            return Ok(new
            {
                OverbookingId = overbooking.Id,
                FlightBookingDetailFareAmount = flightBookingDetail.Fareamount,
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
