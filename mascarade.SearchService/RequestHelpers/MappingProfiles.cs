using AutoMapper;
using mascarade.Contracts;
using mascarade.SearchService.Models;

namespace mascarade.SearchService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CostumeCreated, Costume>();
        CreateMap<CostumeUpdated, Costume>();
    }
}