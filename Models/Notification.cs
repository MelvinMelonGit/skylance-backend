using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("Notifications")]
public class Notification
{
    public Notification()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    [MaxLength(255)]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public virtual OverbookingDetail OverbookingDetail { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Message { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string NotificationType { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string NotificationStatus { get; set; }
}