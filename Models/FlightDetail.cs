using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("FlightDetails")]
public class FlightDetail
{
    public FlightDetail()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    public string Id { get; set; }
}