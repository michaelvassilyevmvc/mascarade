using System.ComponentModel.DataAnnotations.Schema;

namespace mascarade.RentalService.Entities;

[Table("rentals")]
public class Rental
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public Guid CostumeId { get; set; }
    public Costume Costume { get; set; } = null!;

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public decimal TotalPrice { get; set; }
    public RentalStatus Status { get; set; } = RentalStatus.Created;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}