using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("FlightDetails")]
public class FlightDetail
{
    public FlightDetail()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    [MaxLength(255)]
    public string Id { get; set; }
    
    [ForeignKey("AircraftId")]
    public virtual Aircraft Aircraft { get; set; }
    
    [ForeignKey("OriginAirportId")]
    public virtual Airport OriginAirport { get; set; }
    
    [ForeignKey("DestinationAirportId")]
    public virtual Airport DestinationAirport { get; set; }
    
    [Required]
    [MaxLength(255)]
    public DateTime DepartureTime { get; set; }
    
    [Required]
    [MaxLength(255)]
    public DateTime ArrivalTime { get; set; }
    
    [Required]
    [MaxLength(10)]
    public bool IsHoliday { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FlightStatus { get; set; }
    
    [Required]
    [MaxLength(10)]
    public int CheckInCount { get; set; }
    
    [Required]
    [MaxLength(10)]
    public int SeatsSold { get; set; }
}