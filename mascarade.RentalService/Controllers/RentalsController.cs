using AutoMapper;
using mascarade.RentalService.Data;
using mascarade.RentalService.DTOs;
using mascarade.RentalService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mascarade.RentalService.Controllers;

[ApiController]
[Route("api/rentals")]
public class RentalsController : ControllerBase
{
    private readonly RentalDbContext _context;
    private readonly IMapper _mapper;

    public RentalsController(RentalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<RentalDto>>> GetRentals()
    {
        var rentals = await _context.Rentals.ToListAsync();
        return Ok(_mapper.Map<List<RentalDto>>(rentals));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RentalDto>> GetRentalById(Guid id)
    {
        var rental = await _context.Rentals.FirstOrDefaultAsync(x => x.Id == id);
        if (rental is null) return NotFound();
        return Ok(_mapper.Map<RentalDto>(rental));
    }
    
    [HttpPost]
    public async Task<ActionResult<Rental>> CreateRental(CreateRentalDto createRentalDto)
    {
        var rental = _mapper.Map<Rental>(createRentalDto);
        _context.Rentals.Add(rental);
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to create rental");
        return CreatedAtAction(nameof(GetRentalById), new { Id = rental.Id }, _mapper.Map<RentalDto>(rental));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RentalDto>> UpdateRental(Guid id, UpdateRentalDto updateRentalDto)
    {
        var rental = await _context.Rentals.FirstOrDefaultAsync(x => x.Id == id);
        if (rental is null) return NotFound();

        rental.CostumeId = updateRentalDto.CostumeId ?? rental.CostumeId;
        rental.CustomerId = updateRentalDto.CustomerId ?? rental.CustomerId;
        rental.StartDate = updateRentalDto.StartDate ?? rental.StartDate;
        rental.EndDate = updateRentalDto.EndDate ?? rental.EndDate;
        rental.TotalPrice = updateRentalDto.TotalPrice ?? rental.TotalPrice;
        rental.Status = updateRentalDto.Status ?? rental.Status;

        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to update rental");
        return Ok(_mapper.Map<RentalDto>(rental));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRental(Guid id)
    {
        var rental = await _context.Rentals.FindAsync(id);
        if (rental is null) return NotFound();
        _context.Rentals.Remove(rental);
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to delete rental");
        return Ok();
    }
}