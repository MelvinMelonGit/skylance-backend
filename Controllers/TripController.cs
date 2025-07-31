using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Enum;
using skylance_backend.Services;


namespace skylance_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripsController(ITripService tripService)
    {
        _tripService = tripService;
    }

    // GET: api/trips/{bookingId}
    [HttpGet("{bookingId}")]
    public async Task<IActionResult> GetTripDetailsAsync(string flightBookingId)
    {
        var tripDetails = await _tripService.GetTripDetailsAsync(flightBookingId);
        if (tripDetails == null)
            return NotFound();

        return Ok(tripDetails);
    }

    // POST: api/trips/{bookingId}/checkin
    [HttpPost("{bookingId}/checkin")]
    public async Task<IActionResult> CheckIn(string flightBookingId)
    {
        var result = await _tripService.ValidateCheckInAsync(flightBookingId);
        if (!result)
            return BadRequest("Check-in failed.");

        return Ok("Checked in successfully.");
    }

    [HttpPost("{bookingId}/checkin/confirm")]
    public async Task<IActionResult> ConfirmCheckIn(string flightBookingId)
    {
        var result = await _tripService.ConfirmCheckInAsync(flightBookingId);

        if (result != CheckInValidationResult.Allowed)
            return BadRequest("Cannot check-in due to current flight status.");

        var booking = await _context.Bookings.FindAsync(bookingId);
        booking.Status = "Checked-In";
        await _context.SaveChangesAsync();

        return Ok("Checked-in successfully.");
    }

}
