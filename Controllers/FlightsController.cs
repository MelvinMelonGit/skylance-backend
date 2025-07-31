using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;
using skylance_backend.Enum;

namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly SkylanceDbContext db;
        public FlightsController(SkylanceDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetUpcomingFlights()
        {
            //authenticate the logged in user with the session
            var token = Request.Headers["Session-Token"].ToString();
            var session = db.AppUserSessions
                .Include(s => s.AppUser)
                .FirstOrDefault(s => s.Id == token && s.SessionExpiry > DateTime.UtcNow);

            if (session == null)
                return Unauthorized();

            var loggedInUserId = session.AppUser.Id;

            // look for upcoming flights 
            var upcomingFlights = db.FlightBookingDetails
            .Include(fbd => fbd.FlightDetail)
            .Include(fbd => fbd.BookingDetail)
            .Where(fbd =>
                fbd.BookingDetail.AppUser.Id == loggedInUserId &&
                fbd.FlightDetail.DepartureTime > DateTime.Now &&
                fbd.BookingStatus == BookingStatus.Confirmed)
            .Select(fbd => new
            {
                FlightNumber = fbd.FlightDetail.Aircraft.FlightNumber, 
                Origin = fbd.FlightDetail.OriginAirport.Name,
                Destination = fbd.FlightDetail.DestinationAirport.Name,
                DepartureTime = fbd.FlightDetail.DepartureTime,
                SelectedSeat = fbd.SelectedSeat
            })
            .ToList();

            return Ok(upcomingFlights);
        }
    }
}
