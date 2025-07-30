using skylance_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace skylance_backend.Data;

public class SkylanceDbContext : DbContext
{
    public SkylanceDbContext() { }

    public SkylanceDbContext(DbContextOptions<SkylanceDbContext> options)
        : base(options) { }


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
    public DbSet<EmployeeSession> EmployeeSessions { get; set; }
    public DbSet<FlightBookingDetail> FlightBookingDetails { get; set; }
    public DbSet<FlightDetail> FlightDetails { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<OverbookingDetail> OverbookingDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // relationships
        modelBuilder.Entity<FlightDetail>()
            .HasOne(f => f.Aircraft)
            .WithMany()
            .HasForeignKey("AircraftId");

        modelBuilder.Entity<FlightDetail>()
            .HasOne(f => f.OriginAirport)
            .WithMany()
            .HasForeignKey("OriginAirportId");

        modelBuilder.Entity<FlightDetail>()
            .HasOne(f => f.DestinationAirport)
            .WithMany()
            .HasForeignKey("DestinationAirportId");
    }
}