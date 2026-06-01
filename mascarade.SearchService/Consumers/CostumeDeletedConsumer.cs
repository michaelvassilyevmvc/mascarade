using mascarade.Contracts;
using mascarade.SearchService.Models;
using MassTransit;
using MongoDB.Entities;

namespace mascarade.SearchService.Consumers;

public class CostumeDeletedConsumer : IConsumer<CostumeDeleted>
{
    public async Task Consume(ConsumeContext<CostumeDeleted> context)
    {
        Console.WriteLine("--> Consuming costume deleted: " + context.Message.Id);
        var result = await DB.DeleteAsync<Costume>(context.Message.Id);
        if (!result.IsAcknowledged)
        {
            throw new MessageException(typeof(CostumeDeleted), "Problem deleting costume");
        }
    }
}