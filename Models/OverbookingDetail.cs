using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("OverbookingDetails")]
public class OverbookingDetail
{
    [Key]
    [MaxLength(255)]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? OldBookingFlightDetailId { get; set; }
    public string? NewBookingFlightDetailId { get; set; }

    [ForeignKey("OldBookingFlightDetailId")]
    public virtual required FlightBookingDetail? OldBookingFlightDetail { get; set; }

    [ForeignKey("NewBookingFlightDetailId")]
    public virtual required FlightBookingDetail? NewBookingFlightDetail { get; set; }

    [Required]
    public required bool IsRebooking { get; set; }

    [Required]
    public required double FinalCompensationAmount { get; set; }
}