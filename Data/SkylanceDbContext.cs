using Microsoft.EntityFrameworkCore;

namespace skylance_backend.Data;

public class SkylanceDbContext : DbContext
{
    public SkylanceDbContext() {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseMySql(
// provides database connection-string
            "server=localhost;user=root;password=password;database=flipACard;",
            new MySqlServerVersion(new Version(8, 0, 36))
        );
        optionsBuilder.UseLazyLoadingProxies();
    }
// our database tables
}