using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("AppUsers")]
public class AppUser
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }

    [Key]
    [MaxLength(255)]
    public string Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Password { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Salutation { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Gender { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string LastName { get; set; }
    
    [ForeignKey("NationalityId")]
    public virtual Country Nationality { get; set; }
    
    [ForeignKey("MobileCodeId")]
    public virtual Country MobileCode { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string PhoneNumber { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string MembershipTier { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string MembershipNumber { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string PassportNumber { get; set; }
    
    [Required]
    public DateOnly PassportExpiry { get; set; }
    
    [Required]
    public DateOnly DateOfBirth { get; set; }
}