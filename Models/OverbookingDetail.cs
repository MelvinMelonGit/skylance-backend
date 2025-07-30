using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("OverbookingDetails")]
public class OverbookingDetail
{
    [Key]
    [MaxLength(255)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Required]
    [ForeignKey("OldBookingDetailId")]
    public virtual required FlightBookingDetail OldBookingDetail { get; set; }
    
    [Required]
    [ForeignKey("NewBookingDetailId")]
    public virtual required FlightBookingDetail NewBookingDetail { get; set; }
    
    [Required]
    public required bool IsRebooking { get; set; }
    
    [Required]
    public required double FinalCompensationAmount { get; set; }
}