namespace mascarade.RentalService.DTOs;

public class CostumeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Size { get; set; }
    public decimal RentalPriceDay { get; set; }
    public bool IsAvailable { get; set; } 
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}