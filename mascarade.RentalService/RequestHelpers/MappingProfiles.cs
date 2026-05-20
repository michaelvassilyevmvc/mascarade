using AutoMapper;
using mascarade.RentalService.DTOs;
using mascarade.RentalService.Entities;

namespace mascarade.RentalService.RequestHelpers;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Costume, CostumeDto>();
        CreateMap<CreateCostumeDto, Costume>();
        CreateMap<UpdateCostumeDto, Costume>();
        
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, Customer>();
    }
}