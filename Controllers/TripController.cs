using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skylance_backend.Attributes;
using skylance_backend.Enum;
using skylance_backend.Services;

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
    // to display the flight detail page
    [ProtectedRoute]
    [HttpGet("{flightDetailsId}")]
    public async Task<IActionResult> GetTripDetails(Guid flightDetailsId)
    {
        var tripDetails = await _tripService.GetTripDetailsAsync(flightDetailsId);
        if (tripDetails == null)
            return NotFound();

        return Ok(tripDetails);
    }

    // GET: api/trips/{flightDetailsId}/checkin/validate
    // to verify if flight is overbooked or not
    // if it is not, then display confirm check in page
    // if it is, then redirect
    [HttpGet("{flightDetailsId}/checkin/validate")]
    public async Task<IActionResult> ValidateCheckIn(Guid flightDetailsId)
    {
        var result = await _tripService.ValidateCheckInAsync(flightDetailsId);

        return result switch
        {
            CheckInValidationResult.Allowed => Ok("Proceed to confirm check-in."),
            CheckInValidationResult.FlightDeparted => BadRequest("Flight already departed."),
            CheckInValidationResult.FlightFullyCheckedIn => Redirect("/overbooking"),
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