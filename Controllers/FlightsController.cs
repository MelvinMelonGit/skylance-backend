using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Attributes;
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

        // Helper method to get loggedInUserId from session token
        private string? GetLoggedInUserId()
        {
            var token = Request.Headers["Session-Token"].ToString();
            if (string.IsNullOrEmpty(token))
                return null;

            var session = db.AppUserSessions
                .Include(s => s.AppUser)
                .FirstOrDefault(s => s.Id == token && s.SessionExpiry > DateTime.UtcNow);

            return session?.AppUser.Id;
        }

        [ProtectedRoute]
        [HttpGet("UpcomingFlights")]
        public IActionResult GetUpcomingFlights()
        {
            // created loggedInUserId variable to identify the flights with the logged-in user
            var loggedInUserId = GetLoggedInUserId();
            if (loggedInUserId == null)
                return Unauthorized("Invalid or expired session token.");

            var upcomingFlights = db.FlightBookingDetails
                .Include(fbd => fbd.FlightDetail)
                .Include(fbd => fbd.BookingDetail)            
                .Where(fbd =>
                fbd.BookingDetail.AppUser.Id == loggedInUserId &&
                fbd.FlightDetail.DepartureTime > DateTime.Now &&
                fbd.BookingStatus == BookingStatus.Confirmed)
            .Select(fbd => new
            {
                FlightBookingDetailId = fbd.Id,
                FlightNumber = fbd.FlightDetail.Aircraft.FlightNumber,
                Origin = fbd.FlightDetail.OriginAirport.Name,
                Destination = fbd.FlightDetail.DestinationAirport.Name,
                DepartureTime = fbd.FlightDetail.DepartureTime,
                SeatNumber = fbd.SeatNumber
            })
            .ToList();

            return Ok(upcomingFlights);
        }

        [ProtectedRoute]
        [HttpGet("PastFlights")]
        public IActionResult GetPastFlights()
        {
            // created loggedInUserId variable to identify the flights with the logged-in user
            var loggedInUserId = GetLoggedInUserId();
            if (loggedInUserId == null)
                return Unauthorized("Invalid or expired session token.");

            var pastFlights = db.FlightBookingDetails
                .Include(fbd => fbd.FlightDetail)
                .Include(fbd => fbd.BookingDetail)
                .Where(fbd =>
                fbd.BookingDetail.AppUser.Id == loggedInUserId &&
                fbd.BookingStatus == BookingStatus.CheckedIn &&
                fbd.FlightDetail.FlightStatus == "Landed")
                .Select(fbd => new
                {
                    FlightNumber = fbd.FlightDetail.Aircraft.FlightNumber,
                    Origin = fbd.FlightDetail.OriginAirport.Name,
                    Destination = fbd.FlightDetail.DestinationAirport.Name,
                    ArrivalTime = fbd.FlightDetail.ArrivalTime,
                })
                .ToList();

                return Ok(pastFlights);
        }
    }
}



/*
// created loggedInUserId variable to identify the flights with the logged in user
var token = Request.Headers["Session-Token"].ToString();
var session = db.AppUserSessions
    .Include(s => s.AppUser)
    .FirstOrDefault(s => s.Id == token && s.SessionExpiry > DateTime.UtcNow);

if (session == null)
    return Unauthorized();

var loggedInUserId = session.AppUser.Id;
*/
