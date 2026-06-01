namespace mascarade.Contracts;

public class CostumeCreated
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string Size { get; set; }
    public decimal RentalPriceDay { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}