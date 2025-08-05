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
                .FirstOrDefaultAsync(s => s.Id == token);

            if (session == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized - invalid session token");
                return;
            }

            if (session.SessionExpiry <= DateTime.UtcNow)
            {
                dbContext.AppUserSessions.Remove(session);
                await dbContext.SaveChangesAsync();

                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized - session expired");
                return;
            }
            
            context.Items["AppUserSession"] = session;
        }

        await _next(context);
    }
}