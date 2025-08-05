using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;
using skylance_backend.Enum;
using skylance_backend.Models;
using skylance_backend.Services;
using System;

namespace skylance_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmFlightController : ControllerBase
    {
        private readonly SkylanceDbContext _context;
        private readonly Random _random = new Random();
        private readonly ITripService _tripService;

        public ConfirmFlightController(ITripService tripService, SkylanceDbContext context)
        {
            _tripService = tripService;
            _context = context;
        }

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

        [HttpPost("checkin")]
        public async Task<IActionResult> ProcessCheckIn([FromBody] CheckInRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
     
                var bookingDetail = new BookingDetail
                {
                    Id = Guid.NewGuid().ToString(),
                    BookingReferenceNumber = Guid.NewGuid().ToString(),
                    AppUser = await _context.AppUsers.FindAsync(request.AppUserId)
                };
                await _context.BookingDetails.AddAsync(bookingDetail);

               
                double baggageAllowance = Math.Round(15 + _random.NextDouble() * 20, 1);
                string seatNumber = $"{_random.Next(1, 41)}{(char)('A' + _random.Next(0, 6))}";
                bool requireSpecialAssistance = _random.Next(0, 10) < 2; 
                int fareAmount = _random.Next(100, 2001); 
                string gate = _random.Next(1, 51).ToString(); 
                string terminal = _random.Next(1, 4).ToString(); 
                DateTime checkInTime = DateTime.UtcNow;
                DateTime boardingTime = checkInTime.AddMinutes(90); 

                
                var flightBookingDetail = new FlightBookingDetail
                {
                    Id = Guid.NewGuid().ToString(),
                    FlightDetail = await _context.FlightDetails.FindAsync(request.FlightDetailId),
                    BookingDetail = bookingDetail,
                    BaggageAllowance = baggageAllowance,
                    SeatNumber = seatNumber, 
                    RequireSpecialAssistance = requireSpecialAssistance,
                    BookingStatus = BookingStatus.CheckedIn,
                    Fareamount = fareAmount,
                };
                await _context.FlightBookingDetails.AddAsync(flightBookingDetail);

               
                var checkInDetail = new CheckInDetail
                {
                    Id = Guid.NewGuid().ToString(),
                    AppUser = bookingDetail.AppUser,
                    FlightBookingDetail = flightBookingDetail,
                    CheckInTime = checkInTime,
                    BoardingTime = boardingTime,
                    SeatNumber = seatNumber, 
                    Gate = gate,
                    Terminal = terminal
                };
                await _context.CheckInDetails.AddAsync(checkInDetail);

                if (!string.IsNullOrEmpty(request.OverbookingDetailId))
                {
                    var overbookingDetail = await _context.OverbookingDetails
                        .FindAsync(request.OverbookingDetailId);

                    if (overbookingDetail != null)
                    {
                        overbookingDetail.NewFlightBookingDetail = flightBookingDetail;
                        overbookingDetail.IsRebooking = true;
                        overbookingDetail.FinalCompensationAmount = request.FinalCompensationAmount;
                        _context.OverbookingDetails.Update(overbookingDetail);
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new
                {
                    BookingId = bookingDetail.Id,
                    FlightBookingId = flightBookingDetail.Id,
                    CheckInId = checkInDetail.Id,
                    GeneratedValues = new
                    {
                        BaggageAllowance = baggageAllowance,
                        SeatNumber = seatNumber,
                        RequireSpecialAssistance = requireSpecialAssistance,
                        FareAmount = fareAmount,
                        Gate = gate,
                        Terminal = terminal,
                        CheckInTime = checkInTime,
                        BoardingTime = boardingTime
                    }
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{flightBookingId}/boardingPass")]
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


    public class CheckInRequest
    {
        public required string AppUserId { get; set; }
        public required int FlightDetailId { get; set; }

     
        public string? OverbookingDetailId { get; set; }
        public double FinalCompensationAmount { get; set; }
    }
}
