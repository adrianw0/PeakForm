 using Core.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.GetProducts.Request;
public class GetProductsRequest : UseCases.Request
{
    public PagingParams PagingParams { get; set; } = new();
    public string SearchParams { get; set; } = string.Empty;
}
