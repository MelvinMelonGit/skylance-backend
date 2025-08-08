using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;

namespace skylance_backend.Services
{
    public class CompensationService
{
        private readonly SkylanceDbContext _db;
        public CompensationService(SkylanceDbContext db)
        {
            _db = db;
        }
        public async Task<double> CalculateCompensationAsync(string flightBookingDetailId)
        {
            var distance = await GetFlightDistanceAsync(flightBookingDetailId);
            return CalculateCompensationByDistance(distance);
        }

        private async Task<double> GetFlightDistanceAsync(string flightBookingDetailId)
        {
            return await _db.FlightBookingDetails
                .Where(b => b.Id == flightBookingDetailId)
                .Select(b => b.FlightDetail.Distance)
                .FirstOrDefaultAsync();
        }
        public double CalculateCompensationByDistance(double distance)
        {
            var compensation = 0.0;
            if (distance <= 1500)
            {
                return compensation = 380;
            }
            else if (distance <= 3500)
            {
                compensation = 600;
            }
            else
            {
                compensation = 900;
            }
            return compensation;
        }
    }
}
