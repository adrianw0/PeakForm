namespace Application.UseCases.Products.DeleteProduct.Response;
public class DeleteProductSuccessReposnse : DeleteProductReposnse
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
