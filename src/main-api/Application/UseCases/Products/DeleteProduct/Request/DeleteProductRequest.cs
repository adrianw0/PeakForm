using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.DeleteProduct.Request;
public class DeleteProductRequest : UseCases.Request
{
    [Required]
    public required Guid Id { get; set; }
}
