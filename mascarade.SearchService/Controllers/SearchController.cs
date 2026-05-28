using mascarade.SearchService.Models;
using mascarade.SearchService.RequestHelpers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;

namespace mascarade.SearchService.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController: ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Costume>>> Search([FromQuery] SearchParams searchParams)
    {
        var query = DB.PagedSearch<Costume, Costume>();
        query.Sort(x => x.Ascending(a => a.Name));

        if (!string.IsNullOrEmpty(searchParams.SearchTerm))
        {
            query.Match(MongoDB.Entities.Search.Full, searchParams.SearchTerm)
                .SortByTextScore();
        }

        query = searchParams.OrderBy switch
        {
            "price" => query.Sort(x => x.Ascending(a => a.RentalPriceDay)),
            "new" => query.Sort(x => x.Descending(a => a.CreatedAt)),
            _ => query.Sort(x => x.Ascending(a => a.Name))
        };
        
        query = searchParams.FilterBy switch
        {
            "available" => query.Match(a => a.IsAvailable),
            _ => query.Match(x => x.IsAvailable)
        };

        query.PageNumber(searchParams.PageNumber);
        query.PageSize(searchParams.PageSize);

        var result = await query.ExecuteAsync();
        return Ok(new
        {
            results = result.Results,
            pageCount = result.PageCount,
            totalCount = result.TotalCount
        });
    }
}