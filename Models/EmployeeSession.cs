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
    public DateTime SessionDateTime { get; set; }
    
    [ForeignKey("EmployeeId")]
    public virtual Employee Employee { get; set; }
}