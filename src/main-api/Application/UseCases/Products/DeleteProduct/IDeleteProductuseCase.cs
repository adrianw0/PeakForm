using Application.UseCases.Products.DeleteProduct.Request;
using Application.UseCases.Products.DeleteProduct.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.DeleteProduct;
public interface IDeleteProductuseCase : IUseCase<DeleteProductRequest, DeleteProductReposnse>
{
}
