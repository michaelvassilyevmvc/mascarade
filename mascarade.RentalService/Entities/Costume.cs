using System.ComponentModel.DataAnnotations.Schema;

namespace mascarade.RentalService.Entities;

[Table("costumes")]
public class Costume
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Size { get; set; }

    public decimal RentalPriceDay { get; set; }
    public bool IsAvailable { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Rental> Rentals { get; set; } = [];
}