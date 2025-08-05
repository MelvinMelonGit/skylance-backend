using Microsoft.EntityFrameworkCore;
using skylance_backend.Data;
using skylance_backend.Middlewares;
using skylance_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add services to the container.

// Remove duplicate AddDbContext and consolidate with options
builder.Services.AddDbContext<SkylanceDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ).UseLazyLoadingProxies());

builder.Services.AddScoped<ITripService, TripService>();

builder.Services.AddControllers();

// Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SkylanceDbContext>();
    db.Database.Migrate();
}

// Use CORS BEFORE routing (and BEFORE Authorization)
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<AuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

// Initialize DB with migrations instead of EnsureCreated()
initDB();

app.Run();

void initDB()
{
    using (var scope = app.Services.CreateScope())
    {
        var ctx = scope.ServiceProvider.GetRequiredService<SkylanceDbContext>();
        try
        {
            // Apply any pending migrations on startup (better than EnsureCreated)
            ctx.Database.Migrate();
        }
        catch (Exception ex)
        {
            // Log or handle exceptions here if needed
            Console.WriteLine($"DB Migration error: {ex.Message}");
            throw;
        }
    }
}