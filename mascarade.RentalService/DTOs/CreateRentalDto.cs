using mascarade.RentalService.Entities;

namespace mascarade.RentalService.DTOs;

public class CreateRentalDto
{
    public Guid CustomerId { get; set; }
    public Guid CostumeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public RentalStatus Status { get; set; }
}