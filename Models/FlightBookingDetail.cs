using skylance_backend.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("FlightBookingDetails")]
public class FlightBookingDetail
{
    [Key]
    [MaxLength(255)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Required]
    [ForeignKey("FlightDetailId")]
    public virtual required FlightDetail FlightDetail { get; set; }
    
    [Required]
    [ForeignKey("BookingDetailId")]
    public virtual required BookingDetail BookingDetail { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string TravelPurpose { get; set; }

    [Required]
    public required double BaggageAllowance { get; set; }

    [Required]
    [MaxLength(50)]
    public required string SelectedSeat { get; set; }

    [Required]
    public required bool RequireSpecialAssistance { get; set; }

    [Required]
    [MaxLength(50)]
    public required BookingStatus BookingStatus { get; set; }

    [Required]
    [MaxLength(50)]
    public required int Fareamount { get; set; }

    //[Required]
    //public required bool CheckinStatus { get; set; }
}