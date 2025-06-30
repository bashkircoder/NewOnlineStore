using FluentValidation;
using OnlineStore.Domain;

namespace OnlineStore.Application.ProductCategories.Commands.ProductCategoryDelete;

    public class ProductCategoryDeleteValidation : AbstractValidator<int>
    {
        public ProductCategoryDeleteValidation()
        {
            RuleFor(deleteProductCategoryCommand =>
                    deleteProductCategoryCommand)
                .GreaterThan(0)
                .WithMessage("id не может быть меньше или равно нулю");
        }
    }
