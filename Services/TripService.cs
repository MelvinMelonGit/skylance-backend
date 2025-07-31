using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;
using skylance_backend.Enum;
using skylance_backend.Models;
using System;

namespace skylance_backend.Services
{
    public class TripService : ITripService
    {
        private readonly SkylanceDbContext _context;

        public TripService(SkylanceDbContext context)
        {
            _context = context;
        }

        public async Task<TripDetailDTO> GetTripDetailsAsync(string flightBookingId)
        {
            var flightBooking = await _context.FlightBookingDetails
                .Include(fb => fb.FlightDetail)
                .FirstOrDefaultAsync(fb => fb.Id == flightBookingId);

            if (flightBooking == null) return null;

            var flight = flightBooking.FlightDetail;

            return new TripDetailDTO
            {
                FlightNumber = flight.Aircraft.FlightNumber,
                OriginAirportCode = flight.OriginAirport.IataCode,
                OriginAirportName = flight.OriginAirport.Name,
                DestinationAirportCode = flight.DestinationAirport.IataCode,
                DestinationAirportName = flight.DestinationAirport.Name,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                FlightDuration = flight.ArrivalTime - flight.DepartureTime
            };
        }

        public async Task<CheckInValidationResult> ValidateCheckInAsync(string flightBookingId)
        {
            var flightBooking = await _context.FlightBookingDetails
                .Include(fb => fb.FlightDetail)
                .FirstOrDefaultAsync(fb => fb.Id == flightBookingId);

            if (flightBooking == null)
                throw new Exception("Booking not found");

            var flight = flightBooking.FlightDetail;

            if (flight.DepartureTime <= DateTime.UtcNow)
                return CheckInValidationResult.FlightDeparted;

            var checkedInCount = await _context.FlightBookingDetails
                .Where(fb => fb.FlightDetail.Id == flight.Id && fb.BookingStatus == BookingStatus.CheckedIn)
                .CountAsync();

            var seatCapacity = flight.Aircraft.SeatCapacity;

            if (checkedInCount >= seatCapacity)
                return CheckInValidationResult.FlightFullyCheckedIn;

            return CheckInValidationResult.Allowed;
        }

        public async Task<bool> ConfirmCheckInAsync(string flightBookingId)
        {
            var flightBooking = await _context.FlightBookingDetails
                .Include(fb => fb.FlightDetail)
                .FirstOrDefaultAsync(fb => fb.Id == flightBookingId);

            if (flightBooking == null || flightBooking.BookingStatus == BookingStatus.CheckedIn)
                return false;

            if (flightBooking.FlightDetail.DepartureTime <= DateTime.UtcNow)
                return false;

            // (Optional) Check seat availability

            flightBooking.BookingStatus = BookingStatus.CheckedIn;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}