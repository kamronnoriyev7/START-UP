using Microsoft.EntityFrameworkCore;
using SportTime.DAL.Configuration;
using SportTime.DAL.Entities;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace SportTime.DAL;

public class MainContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Stadium> Stadiums { get; set; }




    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new StadiumConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new BookingConfiguration());
    }
}
