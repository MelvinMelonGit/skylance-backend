using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("Airports")]
public class Airport
{
    public Airport()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    [MaxLength(255)]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string IATACode { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    
    [ForeignKey("CityId")]
    public virtual City City { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string TimeZone { get; set; }
}