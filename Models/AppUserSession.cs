using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("AppUserSessions")]
public class AppUserSession
{
    [Key]
    [MaxLength(255)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Required]
    [MaxLength(255)]
    public required DateTime SessionDateTime { get; set; }
    
    [Required]
    [ForeignKey("AppUserId")]
    public virtual required AppUser AppUser { get; set; }
}