using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<WashingMachine> WashingMachines => Set<WashingMachine>();
    public DbSet<Programs> Programs => Set<Programs>();
    public DbSet<Purchase> Purchases => Set<Purchase>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WashingMachine>()
            .HasIndex(w => w.SerialNumber)
            .IsUnique();

        modelBuilder.Entity<Programs>()
            .HasIndex(p => p.Name)
            .IsUnique();
    }
}
