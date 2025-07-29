using Microsoft.AspNetCore.Mvc;
using skylance_backend.Attributes;
using skylance_backend.Data;
using skylance_backend.Models;

namespace skylance_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly SkylanceDbContext _db;

    public AuthController(SkylanceDbContext db)
    {
        _db = db;
    }
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDTO request)
    {
        // Replace this with your real user validation
        if (IsValidUser(request.Email, request.Password))
        {
            // 1. Validate user (basic example)
            var user = _db.AppUsers
                 .FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);

             if (user == null)
                 return Unauthorized("Invalid credentials");

             // 2. Generate token (just a secure random string or Guid here)
             var token = Guid.NewGuid().ToString();

             // 3. Save session in database
             var session = new AppUserSession
             {
                 Id = token,
                 AppUser = user,
                 SessionExpiry = DateTime.UtcNow.AddHours(1)
             };

             _db.AppUserSessions.Add(session);
             _db.SaveChanges();

            return Ok(new
            {
                token,
                expires = DateTime.UtcNow.AddHours(1)
            });
        }

        return Unauthorized();
    }
    
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequestDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Check for duplicate email synchronously
        if (_db.AppUsers.Any(u => u.Email == dto.Email))
            return Conflict("Email already registered.");

        // Lookup related Country entities synchronously
        var nationality = _db.Countries.Find(dto.NationalityId);
        var mobileCode = _db.Countries.Find(dto.MobileCodeId);

        if (nationality == null || mobileCode == null)
            return BadRequest("Invalid nationality or mobile code.");

        var newUser = new AppUser
        {
            Email = dto.Email,
            Password = dto.Password,  // Remember to hash passwords in real apps
            Salutation = dto.Salutation,
            Gender = dto.Gender,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Nationality = nationality,
            MobileCode = mobileCode,
            MobileNumber = dto.MobileNumber,
            MembershipTier = dto.MembershipTier,
            MembershipNumber = dto.MembershipNumber,
            PassportNumber = dto.PassportNumber,
            PassportExpiry = dto.PassportExpiry,
            DateOfBirth = dto.DateOfBirth
        };

        _db.AppUsers.Add(newUser);
        _db.SaveChanges();  // Synchronous save

        return CreatedAtAction(nameof(Register), new { id = newUser.Id }, newUser);
    }
    
    [ProtectedRoute]
    [HttpGet("secret")]
    public IActionResult Secret() => Ok("Super secret protected data");
    
    [HttpGet("not-secret")]
    public IActionResult NotSecret() => Ok("Not Super secret protected data");
    
    private bool IsValidUser(string email, string password)
    {
        // Simple hardcoded check for example only
        return email == "user@example.com" && password == "password";
    }
}