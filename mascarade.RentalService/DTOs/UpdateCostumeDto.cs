namespace mascarade.RentalService.DTOs;

public class UpdateCostumeDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string Size { get; set; }
    public required decimal RentalPriceDay { get; set; }
    public required bool IsAvailable { get; set; } 
}