namespace Application.UseCases.Products.AddProduct.Response;
public class AddProductErrorResposnse : AddProductResposnse
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
