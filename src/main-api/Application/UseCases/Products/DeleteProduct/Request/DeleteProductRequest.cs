using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Products.DeleteProduct.Request;
public class DeleteProductRequest : UseCases.Request
{
    [Required]
    public required Guid Id { get; set; }
}
