using FluentValidation;
using OnlineStore.Application.Products.Commands.ProductCreate;
using OnlineStore.Domain;

namespace OnlinestoreUnitTest;

public class ProductCreateValidationTest
{
    [Fact]
    public void ProductCreateValidationTest_Correct()
    {
        //Arange
        var product = new Product
        {
            Name = "name",
            Description = "description",
            Price = 100,
            ProductCategoryId = 1
        };
        
        //Act

        var productCreateValidation = new ProductCreateValidation();
        var result = productCreateValidation.Validate(product);
        
        //Assert
        
        Assert.True(result.IsValid);
        
    }
    
    [Fact]
    public void ProductPriceValidationTest_NotCorrect()
    {
        //Arange
        var product = new Product
        {
            Name = "name",
            Description = "description",
            Price = -100,
            ProductCategoryId = 1
        };
        
        //Act

        var productCreateValidation = new ProductCreateValidation();
        var result = productCreateValidation.Validate(product);
        
        //Assert
        
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(Product.Price)
        && error.ErrorMessage == "Цена товара должна быть больше нуля.");
    }
}