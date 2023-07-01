using Application.UseCases.Products.AddProduct.Request;
using Application.UseCases.Products.AddProduct.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.AddProduct;
public interface IAddProductUseCase : IUseCase<AddProductRequest, AddProductResposnse>
{
}
