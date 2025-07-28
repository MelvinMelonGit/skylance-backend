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
    public string Id { get; set; }
}