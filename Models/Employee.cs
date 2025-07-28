using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skylance_backend.Models;

[Table("Employees")]
public class Employee
{
    public Employee()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Key]
    [MaxLength(255)]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Username { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Password { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Rank { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Position { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string EmployeeNumber { get; set; }
}