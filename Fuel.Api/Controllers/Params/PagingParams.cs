namespace Fuel.Api.Controllers.Params;

public class PagingParams
{
    public int PageSize { get => _pageSize; set => _pageSize = value > _maxPageSize ? _maxPageSize : value; }
    public int Page { get; set; } = 1;


    private int _pageSize = 10;
    private const int _maxPageSize = 50;
}
