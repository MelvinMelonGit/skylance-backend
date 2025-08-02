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
            var token = context.Request.Headers["Session-Token"].FirstOrDefault();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized - missing session token");
                return;
            }

            var session = await dbContext.AppUserSessions
                .Include(s => s.AppUser)
                .FirstOrDefaultAsync(s => s.Id == token && s.SessionExpiry > DateTime.UtcNow);

            if (session == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized - invalid or expired session token");
                return;
            }

            // Optional: store session or user info in HttpContext.Items if you want to use it later
            context.Items["AppUserSession"] = session;
        }

        await _next(context);
    }
}