using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("FlightBookingDetails")]
public class FlightBookingDetail
{
    public FlightBookingDetail()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    [MaxLength(255)]
    public string Id { get; set; }
    
    [Required]
    [ForeignKey("FlightDetailId")]
    public virtual required FlightDetail FlightDetail { get; set; }
    
    [Required]
    [ForeignKey("BookingDetailId")]
    public virtual required BookingDetail BookingDetail { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string TravelPurpose { get; set; }
}