namespace skylance_backend.Models
{
    public class TripDetailDto
    {
        public string FlightNumber { get; set; }
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string SeatNumber { get; set; }
        public string Status { get; set; }
    }
}
