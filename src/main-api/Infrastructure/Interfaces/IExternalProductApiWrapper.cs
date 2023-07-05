using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces;
public interface IExternalProductApiWrapper
{
    public Task<List<Domain.Models.Product>> GetProductsAsync(string searchParam);
}
