using FluentValidation;

namespace OnlineStore.Application.Products.Commands.ProductDelete;

public class ProductDeleteValidation : AbstractValidator<int>
{
    public ProductDeleteValidation()
    {
        RuleFor(deleteProductCategoryCommand =>
                deleteProductCategoryCommand)
            .GreaterThan(0)
            .WithMessage("id не может быть меньше или равно нулю");
    }
}