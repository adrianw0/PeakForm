using Domain.Models;

namespace Application.UseCases.Products.AddProduct.Response;
public class AddProductSuccessResponse : AddProductResposnse
{
    public Product Product { get; set; }
}
