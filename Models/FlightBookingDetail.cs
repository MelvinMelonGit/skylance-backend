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
    
    [ForeignKey("FlightDetailId")]
    public virtual FlightDetail FlightDetail { get; set; }
    
    [ForeignKey("BookingDetailId")]
    public virtual BookingDetail BookingDetail { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string TravelPurpose { get; set; }
}