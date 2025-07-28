using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("AppUserSessions")]
public class AppUserSession
{
    public AppUserSession()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    [MaxLength(255)]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public DateTime SessionDateTime { get; set; }
    
    [ForeignKey("AppUserId")]
    public virtual AppUser AppUser { get; set; }
}