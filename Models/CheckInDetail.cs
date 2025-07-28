using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("CheckInDetails")]
public class CheckInDetail
{
    public CheckInDetail()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    [MaxLength(255)]
    public string Id { get; set; }
    
    [ForeignKey("AppUserId")]
    public virtual AppUser AppUser { get; set; }
    
    [ForeignKey("FlightBookingDetailId")]
    public virtual FlightBookingDetail FlightBookingDetail { get; set; }
    
    [Required]
    [MaxLength(255)]
    public DateTime CheckInTime { get; set; }
    
    [Required]
    [MaxLength(255)]
    public DateTime BoardingTime { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string SeatNumber { get; set; }
    
    [Required]
    [MaxLength(10)]
    public int Gate { get; set; }
    
    [Required]
    [MaxLength(10)]
    public int Terminal { get; set; }
}