using AutoMapper;
using mascarade.Contracts;
using mascarade.SearchService.Models;
using MassTransit;
using MongoDB.Entities;

namespace mascarade.SearchService.Consumers;

public class CostumeUpdatedConsumer : IConsumer<CostumeUpdated>
{
    private readonly IMapper _mapper;

    public CostumeUpdatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<CostumeUpdated> context)
    {
        Console.WriteLine("--> Consuming costume updated: " + context.Message.Id);
        var costume = _mapper.Map<Costume>(context.Message);

        var result = await DB.Update<Costume>()
            .MatchID(context.Message.Id)
            .ModifyOnly(x => new
            {
                x.Name,
                x.Description,
                x.ImageUrl,
                x.Size,
                x.RentalPriceDay,
                x.IsAvailable
            }, costume)
            .ExecuteAsync();
        if (!result.IsAcknowledged)
        {
            throw new MessageException(typeof(CostumeUpdated), "Problem updating mongodb");
        }
    }
}