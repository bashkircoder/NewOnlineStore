using FluentValidation;
using OnlineStore.Application.RepositoryInterfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.ProductCategories.Commands.ProductCategoryCreate;

public class CreateProductCategoryHandler(IRepositoryProductCategory repository, ProductCategoryCreateValidation productCategoryCreateValidation)
{
    public async Task Execute(ProductCategory productCategory)
    {
        productCategoryCreateValidation.ValidateAndThrow(productCategory);
        await repository.AddAsync(productCategory);
    }
}