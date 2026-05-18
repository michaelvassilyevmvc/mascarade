using System.ComponentModel.DataAnnotations.Schema;

namespace mascarade.RentalService.Entities;

[Table("customers")]
public class Customer
{
    public Guid Id { get; set; }
    [Column("full_name")]
    public string FullName { get; set; } = null!;
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = null!;
    public string? Email { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Rental> Rentals { get; set; } = [];
}