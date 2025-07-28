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
    public string Id { get; set; }
}