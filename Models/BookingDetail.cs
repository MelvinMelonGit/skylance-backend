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
    public required string BookingReferenceNumber { get; set; }
    
    [Required]
    [ForeignKey("AppUserId")]
    public virtual required AppUser AppUser { get; set; }

    [Required]
    [ForeignKey("FlightDetailId")]
    public virtual required FlightDetail FlightDetail { get; set; }
    
    [Required]
    public required double FareAmount { get; set; }
    
    [Required]
    public required double BaggageAllowance { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string SelectedSeat { get; set; }
    
    [Required]
    public required bool RequireSpecialAssistance { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string BookingStatus { get; set; }
}