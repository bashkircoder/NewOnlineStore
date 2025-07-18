using OnlineStore.Application.ProductCategories.Commands.ProductCategoryCreate;
using OnlineStore.Domain;

namespace OnlinestoreUnitTest;

public class ProductCategoryCreateValidationTest
{
    [Fact]
    public void ProductCategoryCreateValidationTest_Correct()
    {
        //Arange
        
        var productCategory = new ProductCategory()
        {
            Name = "Product category",
            Description = "Product category description",
            
        };
        
        //Act

        var productCreateValidation = new ProductCategoryCreateValidation();
        var result = productCreateValidation.Validate(productCategory);
        
        //Assert
        
        Assert.True(result.IsValid);
        
    }
}