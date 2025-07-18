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
    
    [Fact]
    public void ProductNameLengthValidationTest_NotCorrect()
    {
        //Arange
        var product = new Product
        {
            Name = "ddbdfgbdfbdfbafbafbafbafbadfbafbafbadfbname",
            Description = "description",
            Price = 100,
            ProductCategoryId = 1
        };
        
        //Act

        var productCreateValidation = new ProductCreateValidation();
        var result = productCreateValidation.Validate(product);
        
        //Assert
        
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(Product.Name)
                                                && error.ErrorMessage == "Название товара не должно превышать 20 символов.");
    }
    
    [Fact]
    public void ProductDescriptionLengthValidationTest_NotCorrect()
    {
        //Arange
        var product = new Product
        {
            Name = "name",
            Description = "daBRABDFBSADTYNJETYJETUYJEYJEYJERYJE,MUYKMUTMETUMEUMescription",
            Price = 100,
            ProductCategoryId = 1
        };
        
        //Act

        var productCreateValidation = new ProductCreateValidation();
        var result = productCreateValidation.Validate(product);
        
        //Assert
        
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(Product.Description)
                                                && error.ErrorMessage == "Описание товара не должно превышать 25 символов.");
    }
    
    [Fact]
    public void ProductNameEmptyValidationTest_NotCorrect()
    {
        //Arange
        var product = new Product
        {
            Name = null,
            Description = "description",
            Price = 100,
            ProductCategoryId = 1
        };
        
        //Act

        var productCreateValidation = new ProductCreateValidation();
        var result = productCreateValidation.Validate(product);
        
        //Assert
        
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(Product.Name)
                                                && error.ErrorMessage == "Название товара обязательно для заполнения.");
    }
    
    [Fact]
    public void ProductDescriptionEmptyValidationTest_NotCorrect()
    {
        //Arange
        var product = new Product
        {
            Name = "name",
            Description = null,
            Price = 100,
            ProductCategoryId = 1
        };
        
        //Act

        var productCreateValidation = new ProductCreateValidation();
        var result = productCreateValidation.Validate(product);
        
        //Assert
        
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(Product.Description)
                                                && error.ErrorMessage == "Описание товара обязательно для заполнения.");
    }
}