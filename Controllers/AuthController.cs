using Microsoft.AspNetCore.Mvc;
using skylance_backend.Attributes;
using skylance_backend.Data;
using skylance_backend.Models;

namespace skylance_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly SkylanceDbContext _dbContext;

    public AuthController(SkylanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDTO request)
    {
        // Replace this with your real user validation
        if (IsValidUser(request.Email, request.Password))
        {
            // 1. Validate user (basic example)
            var user = _dbContext.AppUsers
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

             _dbContext.AppUserSessions.Add(session);
             _dbContext.SaveChanges();

            return Ok(new
            {
                token,
                expires = DateTime.UtcNow.AddHours(1)
            });
        }

        return Unauthorized();
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