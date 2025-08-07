using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;
using skylance_backend.Enum;

namespace skylance_backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class FlightBookingController : ControllerBase
    {
        private readonly SkylanceDbContext _context;

        public FlightBookingController(SkylanceDbContext context)
        {
            _context = context;
        }

        [HttpGet("allpassengers")]
        public async Task<IActionResult> GetAllPassengers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;

            var totalRecords = await _context.FlightBookingDetails.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var data = await _context.FlightBookingDetails
                .OrderBy(f => f.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(f => new PassengerDetailsDTO
                {
                    PassengerId = f.BookingDetail.AppUser.Id,
                    FlightNumber = f.FlightDetail.Aircraft.FlightNumber,
                    Airline = f.FlightDetail.Aircraft.Airline,
                    PassengerName = (f.BookingDetail.AppUser.FirstName) + f.BookingDetail.AppUser.LastName,
                    Class = f.Class,
                    MembershipTier = f.BookingDetail.AppUser.MembershipTier,
                    DateOfTravel = f.FlightDetail.DepartureTime,
                    BookingStatus = f.BookingStatus.ToString(),
                    BaggageAllowance = f.BaggageAllowance.ToString(),
                    BaggageChecked = f.BaggageChecked.ToString(),
                    SeatNumber = f.SeatNumber.ToString(),
                    CheckinStatus = f.BookingStatus == BookingStatus.CheckedIn
                    ? "Checked-In"
                    : f.BookingStatus == BookingStatus.Confirmed
                    ? "Not Checked-In"
                    : "Not Applicable",
                    BookingReferenceNumber = f.BookingDetail.BookingReferenceNumber,
                    Email = f.BookingDetail.AppUser.Email,
                    PhoneNumber = f.BookingDetail.AppUser.MobileNumber,
                    PassportNumber = f.BookingDetail.AppUser.PassportNumber,
                    DepartureCity = f.FlightDetail.OriginAirport.City.Name,
                    ArrivalCity = f.FlightDetail.DestinationAirport.City.Name,
                    SpecialRequests = f.SpecialRequest.ToString()
                })
                .ToListAsync();

            var result = new
            {
                success = true,
                message = "Passenger details fetched successfully.",
                pagination = new
                {
                    currentPage = page,
                    pageSize = pageSize,
                    totalRecords = totalRecords,
                    totalPages = totalPages
                },
                data = data
            };

            return Ok(result);
        }
    }

}
