using Microsoft.EntityFrameworkCore;
using skylance_backend.Attributes;
using skylance_backend.Data;

namespace skylance_backend.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var dbContext = context.RequestServices.GetRequiredService<SkylanceDbContext>();
        
        var endpoint = context.GetEndpoint();
        var requiresAuth = endpoint?.Metadata.GetMetadata<ProtectedRouteAttribute>() != null;

        if (requiresAuth)
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized - missing token");
                return;
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();

            var session = await dbContext.AppUserSessions
                .FirstOrDefaultAsync(s => s.Id == token && s.SessionExpiry > DateTime.UtcNow);

            if (session == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized - invalid or expired token");
                return;
            }
        }

        await _next(context);
    }
}