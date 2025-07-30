using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;
using skylance_backend.Enum;
using skylance_backend.Models;
using System;

namespace skylance_backend.Service_Layer
{
    public class TripService : ITripService
    {
        private readonly SkylanceDbContext _context;

        public TripService(SkylanceDbContext context)
        {
            _context = context;
        }

        public async Task<TripDetailsDto> GetTripDetailsAsync(Guid flightDetailId)
        {
            var flightDetails = await _context.FlightDetails
                .Include(f => f.Flight)
                .FirstOrDefaultAsync(f => f.Id == flightDetailId);

            if (flightDetails == null) return null;

            return new TripDetailsDto
            {
                FlightNumber = flightDetails.Flight.FlightNumber,
                OriginAirport = flightDetails.Flight.Origin,
                DestinationAirport = flightDetails.Flight.Destination,
                DepartureTime = flightDetails.Flight.DepartureTime,
                ArrivalTime = flightDetails.Flight.ArrivalTime
            };
        }

        public async Task<CheckInValidationResult> ValidateCheckInAsync(Guid bookingDetailId)
        {
            var booking = await _context.BookingDetails
                .Include(b => b.flightDetail)
                .FirstOrDefaultAsync(b => b.Id == bookingDetailId);

            if (booking == null)
                throw new Exception("Booking not found");

            var flight = flightDetail.Flight;

            if (flight.DepartureTime <= DateTime.UtcNow)
                return CheckInValidationResult.FlightDeparted;

            var checkedInCount = await _context.FlightDetails
                .CountAsync(f => f.FlightId == flight.Id && f.Status == "Checked-In");

            var seatCapacity = flight.SeatCapacity;

            if (checkedInCount >= seatCapacity)
                return CheckInValidationResult.FlightFullyCheckedIn;

            return CheckInValidationResult.Allowed;
        }

        public async Task<bool> ConfirmCheckInAsync(Guid flightDetailsId)
        {
            var flightDetails = await _context.FlightDetails
                .Include(f => f.Flight)
                .FirstOrDefaultAsync(f => f.Id == flightDetailsId);

            if (flightDetails == null || flightDetails.Status == "Checked-In")
                return false;

            if (flightDetails.Flight.DepartureTime <= DateTime.UtcNow)
                return false;

            // (Optional) Check seat availability

            flightDetails.Status = "Checked-In";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}