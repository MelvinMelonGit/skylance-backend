using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("Aircraft")]
public class Aircraft
{
    public Aircraft()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    public string Id { get; set; }
}