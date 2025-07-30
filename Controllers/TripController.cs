using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Enums;
using skylance_backend.Service_Layer;

namespace skylance_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TripController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripController(ITripService tripService)
    {
        _tripService = tripService;
    }

    // GET: api/trips/{flightDetailsId}
    [HttpGet("{flightDetailsId}")]
    public async Task<IActionResult> GetTripDetails(Guid flightDetailsId)
    {
        var tripDetails = await _tripService.GetTripDetailsAsync(flightDetailsId);
        if (tripDetails == null)
            return NotFound();

        return Ok(tripDetails);
    }

    // GET: api/trips/{flightDetailsId}/checkin/validate
    [HttpGet("{flightDetailsId}/checkin/validate")]
    public async Task<IActionResult> ValidateCheckIn(Guid flightDetailsId)
    {
        var result = await _tripService.ValidateCheckInAsync(flightDetailsId);

        return result switch
        {
            CheckInValidationResult.Allowed => Ok("Proceed to confirm check-in."),
            CheckInValidationResult.FlightDeparted => BadRequest("Flight already departed."),
            CheckInValidationResult.FlightFullyCheckedIn => Redirect("/rebooking"),
            _ => BadRequest("Unknown error.")
        };
    }

    [HttpPost("{flightDetailsId}/checkin/confirm")]
    public async Task<IActionResult> ConfirmCheckIn(Guid flightDetailsId)
    {
        var result = await _tripService.ConfirmCheckInAsync(flightDetailsId);
        return result ? Ok("Checked in successfully.") : BadRequest("Check-in failed.");
    }

}