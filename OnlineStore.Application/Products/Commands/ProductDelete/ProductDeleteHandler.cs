using FluentValidation;
using OnlineStore.Application.RepositoryInterfaces;

namespace OnlineStore.Application.Products.Commands.ProductDelete;

public class ProductDeleteHandler(IRepositoryProduct repository, ProductDeleteValidation productDeleteValidation)
{
    public async Task Execute(int id)
    {
        productDeleteValidation.ValidateAndThrow(id);
        await repository.RemoveAsync(id);
    }
}