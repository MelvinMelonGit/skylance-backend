using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("BookingDetails")]
public class BookingDetail
{
    public BookingDetail()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    [MaxLength(255)]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string BookingReferenceNumber { get; set; }
    
    [ForeignKey("AppUserId")]
    public virtual AppUser AppUser { get; set; }

    [ForeignKey("FlightDetailId")]
    public virtual FlightDetail FlightDetail { get; set; }
    
    [Required]
    [MaxLength(50)]
    public double FareAmount { get; set; }
    
    [Required]
    [MaxLength(50)]
    public double BaggageAllowance { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string SelectedSeat { get; set; }
    
    [Required]
    [MaxLength(10)]
    public bool RequireSpecialAssistance { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string BookingStatus { get; set; }
}