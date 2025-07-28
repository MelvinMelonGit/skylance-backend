using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("FlightDetails")]
public class FlightDetail
{
    [Key]
    [MaxLength(255)]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [ForeignKey("AircraftId")]
    public virtual required Aircraft Aircraft { get; set; }

    [Required]
    [ForeignKey("OriginAirportId")]
    public virtual required Airport OriginAirport { get; set; }

    [Required]
    [ForeignKey("DestinationAirportId")]
    public virtual required Airport DestinationAirport { get; set; }

    [Required]
    public required DateTime DepartureTime { get; set; }

    [Required]
    public required DateTime ArrivalTime { get; set; }

    [Required]
    public required bool IsHoliday { get; set; }

    [Required]
    [MaxLength(50)]
    public required string FlightStatus { get; set; }

    [Required]
    public required int CheckInCount { get; set; }

    [Required]
    public required int SeatsSold { get; set; }
}
