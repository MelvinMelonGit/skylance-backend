using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("EmployeeSessions")]
public class EmployeeSession
{
    public EmployeeSession()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    [MaxLength(255)]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public required DateTime SessionDateTime { get; set; }
    
    [Required]
    [ForeignKey("EmployeeId")]
    public virtual required Employee Employee { get; set; }
}