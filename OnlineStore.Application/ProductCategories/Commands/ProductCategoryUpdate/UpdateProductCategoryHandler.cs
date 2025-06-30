using FluentValidation;
using OnlineStore.Application.RepositoryInterfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.ProductCategories.Commands.ProductCategoryUpdate;

public class UpdateProductCategoryHandler(IRepositoryProductCategory repository, ProductCategoryUpdateValidation productCategoryUpdateValidation)
{
    public async Task Execute(ProductCategory productCategory)
    {
        productCategoryUpdateValidation.ValidateAndThrow(productCategory);
        await repository.UpdateAsync(productCategory);
    }
}