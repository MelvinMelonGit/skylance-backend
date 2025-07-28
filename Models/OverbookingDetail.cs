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
    
    [ForeignKey("OldBookingDetailId")]
    public virtual BookingDetail OldBookingDetail { get; set; }
    
    [ForeignKey("NewBookingDetailId")]
    public virtual BookingDetail NewBookingDetail { get; set; }
    
    [Required]
    [MaxLength(10)]
    public bool IsRebooking { get; set; }
    
    [Required]
    [MaxLength(50)]
    public double FinalCompensationAmount { get; set; }
}