using mascarade.RentalService.Entities;
using Microsoft.EntityFrameworkCore;

namespace mascarade.RentalService.Data;

public class RentalDbContext: DbContext
{
    public RentalDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Costume> Costumes { get; set; } = null!;
    public DbSet<Rental> Rentals { get; set; } = null!;
}