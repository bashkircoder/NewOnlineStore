using FluentValidation;
using OnlineStore.Application.RepositoryInterfaces;

namespace OnlineStore.Application.ProductCategories.Commands.ProductCategoryDelete;

public class DeleteProductCategoryHandler(IRepositoryProductCategory repository, ProductCategoryDeleteValidation productCategoryDeleteValidation)
{
    public async Task Execute(int id)
    {
        productCategoryDeleteValidation.ValidateAndThrow(id);
        await repository.RemoveAsync(id);
    }
}