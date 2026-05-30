using mascarade.SearchService.Models;
using MongoDB.Entities;

namespace mascarade.SearchService.Services;

public class CostumeSvcHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public CostumeSvcHttpClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<Costume>> GetCostumesAsync()
    {
        var lastUpdated = await DB.Find<Costume, string>()
            .Sort(x => x.Descending(a => a.UpdatedAt))
            .Project(x => x.UpdatedAt.ToString())
            .ExecuteFirstAsync();
        return await _httpClient
            .GetFromJsonAsync<List<Costume>>(_configuration["CostumeServiceUrl"]
                                             + "/api/costumes?date=" + lastUpdated);
    }
}