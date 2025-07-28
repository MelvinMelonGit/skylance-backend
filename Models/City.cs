using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("Cities")]
public class City
{
    public City()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    [MaxLength(255)]
    public string Id { get; set; }
    
    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
}