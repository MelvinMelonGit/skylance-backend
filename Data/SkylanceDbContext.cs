using skylance_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace skylance_backend.Data;

public class SkylanceDbContext : DbContext
{
    public SkylanceDbContext() {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseMySql(
            // provides database connection-string
            "server=localhost;user=root;password=password;database=skylance;",
            new MySqlServerVersion(new Version(8, 0, 36))
        );
        optionsBuilder.UseLazyLoadingProxies();
    }
    // our database tables
    public DbSet<Aircraft> Aircraft { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppUserSession> AppUserSessions { get; set; }
    public DbSet<BookingDetail> BookingDetails { get; set; }
    public DbSet<CheckInDetail> CheckInDetails { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<FlightBookingDetail> FlightBookingDetails { get; set; }
    public DbSet<FlightDetail> FlightDetails { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<OverbookingDetail> OverbookingDetails { get; set; }
}