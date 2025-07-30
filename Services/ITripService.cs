namespace skylance_backend.Services
{
    public interface ITripService
    {
        Task<TripDetailsDto> GetTripDetailsAsync(Guid bookingId);
        Task<CheckInValidationResult> ValidateCheckInAsync(Guid bookingDetailId);
        Task<bool> ConfirmCheckInAsync(Guid flightDetailsId)
    }
}
