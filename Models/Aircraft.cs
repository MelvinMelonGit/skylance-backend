using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("Aircraft")]
public class Aircraft
{
    public Aircraft()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    public string Id { get; set; }
    
    [Required]
    public string Airline { get; set; }
    
    [Required]
    public string FlightNumber { get; set; }
    
    [Required]
    public string AircraftBrand { get; set; }
    
    [Required]
    public string AircraftModel { get; set; }
    
    [Required]
    public int SeatCapacity { get; set; }
}