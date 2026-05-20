using AutoMapper;
using mascarade.RentalService.Data;
using mascarade.RentalService.DTOs;
using mascarade.RentalService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mascarade.RentalService.Controllers;

[ApiController]
[Route("api/costumes")]
public class CostumesController : ControllerBase
{
    private readonly RentalDbContext _context;
    private readonly IMapper _mapper;

    public CostumesController(RentalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<CostumeDto>>> GetCostumes()
    {
        var costumes = await _context.Costumes.ToListAsync();

        return Ok(_mapper.Map<List<CostumeDto>>(costumes));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CostumeDto>> GetCostumeById(Guid id)
    {
        var costume = await _context.Costumes.FirstOrDefaultAsync(x => x.Id == id);
        if (costume is null) return NotFound();
        return Ok(_mapper.Map<CostumeDto>(costume));
    }

    [HttpPost]
    public async Task<ActionResult<Costume>> CreateCostume(CreateCostumeDto createCostumeDto)
    {
        var costume = _mapper.Map<Costume>(createCostumeDto);
        _context.Costumes.Add(costume);
        var result = await _context.SaveChangesAsync() > 0;
        if (!result)
        {
            return BadRequest("Failed to create costume");
        }

        return CreatedAtAction(nameof(GetCostumeById),
            new { Id = costume.Id },
            _mapper.Map<CostumeDto>(costume));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CostumeDto>> UpdateCostume(Guid id, UpdateCostumeDto updatedCostumeDto)
    {
        var costume = await _context.Costumes.FirstOrDefaultAsync(x => x.Id == id);
        if (costume is null) return NotFound();

        // TODO: authentication

        costume.Name = updatedCostumeDto.Name;
        costume.Description = updatedCostumeDto.Description;
        costume.ImageUrl = updatedCostumeDto.ImageUrl;
        costume.IsAvailable = updatedCostumeDto.IsAvailable;
        costume.Size = updatedCostumeDto.Size;
        costume.RentalPriceDay = updatedCostumeDto.RentalPriceDay;

        var result = await _context.SaveChangesAsync() > 0;
        if (!result)
        {
            return BadRequest("Failed to update costume");
        }

        return Ok(_mapper.Map<CostumeDto>(costume));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCostume(Guid id)
    {
        var costume = await _context.Costumes.FindAsync(id);
        if (costume is null) return NotFound();
        // TODO: check authentification

        _context.Costumes.Remove(costume);
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to delete costume");

        return Ok();
    }
}