using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces;
public interface IExternalProductApiWrapper
{
    public Task<Product?> GetProductByCodeAsync(string searchParam);
    public Task<List<Product>> GetProductsByNameAsync(string searchParam, int pageNumber, int pageSize);
}
