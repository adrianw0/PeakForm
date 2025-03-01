﻿namespace Core.Params;
public class PagingParams
{
    public int PageSize { get => _pageSize; set => _pageSize = value > MaxPageSize ? MaxPageSize : value; }
    public int Page { get; set; } = 1;


    private int _pageSize = 10;

    private const int MaxPageSize = 50;
}
