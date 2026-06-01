using AutoMapper;
using mascarade.Contracts;
using mascarade.SearchService.Models;
using MassTransit;
using MongoDB.Entities;

namespace mascarade.SearchService.Consumers;

public class CostumeCreatedConsumer : IConsumer<CostumeCreated>
{
    private readonly IMapper _mapper;

    public CostumeCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<CostumeCreated> context)
    {
        Console.WriteLine("--> Consuming costume created: " + context.Message.Id);
        var costume = _mapper.Map<Costume>(context.Message);

        await costume.SaveAsync();
    }
}