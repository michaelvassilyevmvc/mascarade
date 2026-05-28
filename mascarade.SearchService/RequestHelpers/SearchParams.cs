namespace mascarade.SearchService.RequestHelpers;

public class SearchParams
{
    public string SearchTerm { get; set; } = string.Empty;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 3;
    public string? OrderBy { get; set; }
    public string? FilterBy { get; set; }
}