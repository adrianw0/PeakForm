using Application.UseCases.Products.AddProduct.Request;
using Application.UseCases.Responses.Add;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using FluentValidation;


namespace Application.UseCases.Products.AddProduct;

public class AddProductUseCase(IWriteRepository<Product> productWriteRepository, IUserProvider userProvider, IValidator<AddProductRequest> requestValidator) : IAddProductUseCase
{
    private readonly IWriteRepository<Product> _productWriteRepository = productWriteRepository;
    private readonly IUserProvider _userProvider = userProvider;
    private readonly IValidator<AddProductRequest> _requestValidator = requestValidator;

    public async Task<AddReponse<Product>> Execute(AddProductRequest request)
    {

        var validationResult = await _requestValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return new AddErrorResponse<Product>
            { ErrorMessage = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)) };

        var product = CreateProductFromRequest(request);
        await _productWriteRepository.InsertOneAsync(product);

        return new AddSuccessResponse<Product> { Entity = product };
    }


    private Product CreateProductFromRequest(AddProductRequest request)
    {
        var baseUnitWeight = request.UnitWeights.SingleOrDefault(x => x.Unit.Code == request.BaseUnit.Code)!.Weight;

        var nutrientsPer1G = GetValuesPer1G(request.Nutrients, baseUnitWeight);

        var product = new Product
        {
            Name = request.Name,
            Ean = request.Ean,
            Description = request.Description,
            NutrientsPer1G = nutrientsPer1G,
            OwnerId = _userProvider.UserId,
            UnitWeights = request.UnitWeights
        };

        return product;
    }

    private static List<NutrientValue> GetValuesPer1G(IEnumerable<NutrientValue> nutrientValuesInBaseUnit, double baseUnitWeight)
    {
        return nutrientValuesInBaseUnit.Select(nutrientValue =>
            new NutrientValue
            {
                Nutrient = nutrientValue.Nutrient,
                Value = nutrientValue.Value / baseUnitWeight
            }).ToList();
    }
}
