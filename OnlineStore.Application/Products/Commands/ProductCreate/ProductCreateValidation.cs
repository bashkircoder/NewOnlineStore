using FluentValidation;
using OnlineStore.Domain;

namespace OnlineStore.Application.Products.Commands.ProductCreate;

public class ProductCreateValidation : AbstractValidator<Product>
{
    private const int MaxNameLength = 20;
    private const int MaxDescriptionLength = 25;

    public ProductCreateValidation()
    {
        RuleFor(createProductCommand =>
                createProductCommand.Name)
            .NotEmpty()
            .WithMessage("Название товара обязательно для заполнения.")
            .MaximumLength(MaxNameLength)
            .WithMessage($"Название товара не должно превышать 20 символов.");

        RuleFor(createProductCommand =>
                createProductCommand.Description)
            .NotEmpty()
            .WithMessage("Описание товара обязательно для заполнения.")
            .MaximumLength(MaxDescriptionLength)
            .WithMessage($"Описание товара не должно превышать 25 символов.");

        RuleFor(createProductCommand =>
                createProductCommand.Price)
            .GreaterThan(0)
            .WithMessage("Цена товара должна быть больше нуля.");
    }
}