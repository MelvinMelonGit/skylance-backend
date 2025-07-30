using skylance_backend.Data;
using skylance_backend.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<MLService>();

// Inject our database context into DI-container
builder.Services.AddDbContext<SkylanceDbContext>();

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

app.UseAuthorization();

app.UseMiddleware<AuthMiddleware>();

app.MapControllers();

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