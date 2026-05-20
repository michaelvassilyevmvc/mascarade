using AutoMapper;
using mascarade.RentalService.Data;
using mascarade.RentalService.DTOs;
using mascarade.RentalService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mascarade.RentalService.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly RentalDbContext _context;
    private readonly IMapper _mapper;

    public CustomersController(RentalDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerDto>>> GetCustomers()
    {
        var customers = await _context.Customers.ToListAsync();
        return Ok(_mapper.Map<CustomerDto>(customers));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(Guid id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        if (customer is null) return NotFound();
        return Ok(_mapper.Map<CustomerDto>(customer));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CreateCustomerDto createCustomerDto)
    {
        var customer = _mapper.Map<Customer>(createCustomerDto);
        _context.Customers.Add(customer);
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to create customer");
        return CreatedAtAction(nameof(GetCustomerById), new { Id = customer.Id }, _mapper.Map<CustomerDto>(customer));
    }

    [HttpPut("{id]")]
    public async Task<ActionResult<CustomerDto>> UpdateCustomer(Guid id, UpdateCustomerDto updateCustomerDto)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        if (customer is null) return NotFound();

        customer.Email = updateCustomerDto.Email ?? customer.Email;
        customer.FullName = updateCustomerDto.FullName ?? customer.FullName;
        customer.PhoneNumber = updateCustomerDto.PhoneNumber ?? customer.PhoneNumber;

        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to update customer");
        return Ok(_mapper.Map<CustomerDto>(customer));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer is null) return NotFound();
        _context.Customers.Remove(customer);
        var result = await _context.SaveChangesAsync() > 0;
        if (!result) return BadRequest("Failed to delete customer");
        return Ok();
    }
}