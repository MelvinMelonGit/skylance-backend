using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("OverbookingDetails")]
public class OverbookingDetail
{
    public OverbookingDetail()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    [MaxLength(255)]
    public string Id { get; set; }
    
    [Required]
    [ForeignKey("OldBookingDetailId")]
    public virtual required BookingDetail OldBookingDetail { get; set; }
    
    [Required]
    [ForeignKey("NewBookingDetailId")]
    public virtual required BookingDetail NewBookingDetail { get; set; }
    
    [Required]
    public required bool IsRebooking { get; set; }
    
    [Required]
    public required double FinalCompensationAmount { get; set; }
}