using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;
using skylance_backend.Enum;
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

                
                var flightBookingDetail = new FlightBookingDetail
                {
                    Id = Guid.NewGuid().ToString(),
                    FlightDetail = await _context.FlightDetails.FindAsync(request.FlightDetailId),
                    BookingDetail = bookingDetail,
                    BaggageAllowance = request.BaggageAllowance,
                    SeatNumber = request.SeatNumber,
                    RequireSpecialAssistance = request.RequireSpecialAssistance,
                    BookingStatus = BookingStatus.Confirmed,
                    Fareamount = request.Fareamount,
                    CheckinStatus = true
                };
                await _context.FlightBookingDetails.AddAsync(flightBookingDetail);

                
                var checkInDetail = new CheckInDetail
                {
                    Id = Guid.NewGuid().ToString(),
                    AppUser = bookingDetail.AppUser,
                    FlightBookingDetail = flightBookingDetail,
                    CheckInTime = request.CheckInTime,
                    BoardingTime = request.BoardingTime,
                    SeatNumber = request.SeatNumber,
                    Gate = request.Gate,
                    Terminal = request.Terminal
                };
                await _context.CheckInDetails.AddAsync(checkInDetail);

                
                if (request.IsOverbooking && !string.IsNullOrEmpty(request.OverbookingDetailId))
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
                    CheckInId = checkInDetail.Id
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    public class CheckInRequest
    {
        
        public required string AppUserId { get; set; }
        public required string FlightDetailId { get; set; }
        public required double BaggageAllowance { get; set; }
        public required string SeatNumber { get; set; }
        public required bool RequireSpecialAssistance { get; set; }
        public required int Fareamount { get; set; }
        public required DateTime CheckInTime { get; set; }
        public required DateTime BoardingTime { get; set; }
        public required int Gate { get; set; }
        public required int Terminal { get; set; }

        //overbookingdetail
        public bool IsOverbooking { get; set; } = false; 
        public string? OverbookingDetailId { get; set; } 
        public double FinalCompensationAmount { get; set; } 
    }
}