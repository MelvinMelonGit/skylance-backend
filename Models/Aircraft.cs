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
    [MaxLength(255)]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Airline { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FlightNumber { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string AircraftBrand { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string AircraftModel { get; set; }
    
    [Required]
    [MaxLength(10)]
    public int SeatCapacity { get; set; }
}