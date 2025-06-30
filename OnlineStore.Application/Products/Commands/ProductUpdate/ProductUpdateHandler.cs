using FluentValidation;
using OnlineStore.Application.RepositoryInterfaces;
using OnlineStore.Domain;

namespace OnlineStore.Application.Products.Commands.ProductUpdate;

public class ProductUpdateHandler(IRepositoryProduct repository, ProductUpdateValidation productUpdateValidation)
{
    public async Task Execute(Product product)
    {
        productUpdateValidation.ValidateAndThrow(product);
        await repository.UpdateAsync(product);
    }
}