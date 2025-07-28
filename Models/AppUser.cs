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
    public string Id { get; set; }

    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Salutation { get; set; }
    
    [Required]
    public string Gender { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [ForeignKey("CountryId")]
    public virtual Country Nationality { get; set; }
    
    [ForeignKey("CountryId")]
    public virtual Country MobileCode { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }
    
    [Required]
    public string MembershipTier { get; set; }
    
    [Required]
    public string MembershipNumber { get; set; }
    
    [Required]
    public string PassportNumber { get; set; }
    
    [Required]
    public DateOnly PassportExpiry { get; set; }
    
    [Required]
    public DateOnly DateOfBirth { get; set; }
}