using System.Text.Json;
using mascarade.SearchService.Models;
using MongoDB.Driver;
using MongoDB.Entities;

namespace mascarade.SearchService.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb",
            MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        await DB.Index<Costume>()
            .Key(x => x.Name, KeyType.Text)
            .CreateAsync();
        var count = await DB.CountAsync<Costume>();
        if (count == 0)
        {
            Console.WriteLine("No data - will attempt to seed");
            var itemData = await File.ReadAllTextAsync("Data/costumes.json");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var costumes = JsonSerializer.Deserialize<List<Costume>>(itemData, options);
            await DB.SaveAsync(costumes);
        }
    }
}