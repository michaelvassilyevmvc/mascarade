namespace mascarade.Contracts;

public class CostumeUpdated
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string Size { get; set; }
    public decimal? RentalPriceDay { get; set; }
    public bool? IsAvailable { get; set; }
}