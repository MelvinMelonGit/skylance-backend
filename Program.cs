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
        policy.WithOrigins(
                "http://localhost:8081"
            )
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add services to the container.

// Inject our database context into DI-container
builder.Services.AddDbContext<SkylanceDbContext>();
builder.Services.AddScoped<ITripService, TripService>();

builder.Services.AddDbContext<SkylanceDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ).UseLazyLoadingProxies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<AuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

// Use CORS before routing
app.UseCors("AllowAll");

initDB(); // this must be run before app.Run();

app.Run();

// init our database
void initDB()
{
    // create the environment to retrieve our database context
    using (var scope = app.Services.CreateScope())
    {
        // get database context from DI-container
        var ctx = scope.ServiceProvider.GetRequiredService<SkylanceDbContext>();
        if (!ctx.Database.CanConnect())
            ctx.Database.EnsureCreated(); // create database
    }
}