using FluentValidation;
using OnlineStore.Domain;

namespace OnlineStore.Application.ProductCategories.Commands.ProductCategoryCreate;

public class ProductCategoryCreateValidation : AbstractValidator<ProductCategory>
{
    private const int MaxCategoryNameLength = 15;
    private const int MaxDescriptionLength = 512;

    public ProductCategoryCreateValidation()
    {
        RuleFor(createProductCategoryCommand =>
                createProductCategoryCommand.Name)
            .NotEmpty()
            .WithMessage("Название категории обязательно для заполнения.")
            .MaximumLength(MaxCategoryNameLength)
            .WithMessage($"Название категории не должно превышать {MaxCategoryNameLength} символов.");

        RuleFor(createProductCategoryCommand =>
                createProductCategoryCommand.Description)
            .NotEmpty()
            .WithMessage("Описание категории обязательно для заполнения.")
            .MaximumLength(MaxDescriptionLength)
            .WithMessage($"Описание категории не должно превышать {MaxDescriptionLength} символов.");
        
    }
}