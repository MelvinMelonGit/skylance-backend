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
    public required string Username { get; set; }
    
    [Required]
    [MaxLength(255)]
    public required string Email { get; set; }
    
    [Required]
    [MaxLength(255)]
    public required string Password { get; set; }
    
    [Required]
    [MaxLength(255)]
    public required string FirstName { get; set; }
    
    [Required]
    [MaxLength(255)]
    public required string LastName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string Rank { get; set; }
    
    [Required]
    [MaxLength(255)]
    public required string Position { get; set; }
    
    [Required]
    [MaxLength(255)]
    public required string EmployeeNumber { get; set; }
}