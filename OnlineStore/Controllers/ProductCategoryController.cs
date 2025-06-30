using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.ProductCategories.Commands.ProductCategoryCreate;
using OnlineStore.Application.ProductCategories.Commands.ProductCategoryDelete;
using OnlineStore.Application.ProductCategories.Commands.ProductCategoryUpdate;
using OnlineStore.Application.ProductCategories.Queries.GetAllProductCategories;
using OnlineStore.Application.ProductCategories.Queries.GetDetailsProductCategory;
using OnlineStore.Application.ProductCategories.Queries.GetRangeProductsCategories;
using OnlineStore.Application.RepositoryInterfaces;
using OnlineStore.Domain;
using OnlineStore.Storage.Exceptions;

namespace OnlineStore.Controllers;

[ApiController]
[Route("api/categories")]
public class ProductCategoryController : Controller
{
    [HttpGet]
    public async Task<ActionResult> GetAllAsync([FromServices] GetAllProductCategoriesHandler getAllProductCategoriesHandler)
    {
        var productCategories = await getAllProductCategoriesHandler.Execute();

        return Ok(productCategories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetByIdAsync([FromServices] GetDetailsProductCategoryHandler getDetailsProductCategoryHandler, int id)
    {
        var productCategory = await getDetailsProductCategoryHandler.Execute(id);

        return Ok(productCategory);
    }

    [HttpGet("{skip}/{take}")]
    public async Task<ActionResult> GetRangeAsync([FromServices] GetRangeProductCategoriesHandler getRangeProductCategoriesHandler,int skip, int take)
    {
        var productCategories = await getRangeProductCategoriesHandler.Execute(skip, take);

        return Ok(productCategories);
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromServices] CreateProductCategoryHandler createProductCategoryHandler, ProductCategory productCategory)
    {
        await createProductCategoryHandler.Execute(productCategory);

        return Created();
    }

    [HttpDelete("{id}")] 
    public async Task<ActionResult> DeleteAsync([FromServices] DeleteProductCategoryHandler deleteProductCategoryHandler, int id)
    {
        try
        {
            await deleteProductCategoryHandler.Execute(id);
        }
        catch (NotFoundException)
        {
            throw;
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromServices] UpdateProductCategoryHandler updateProductCategoryHandler, ProductCategory productCategory)
    {
        try
        {
            await updateProductCategoryHandler.Execute(productCategory);
        }
        catch (NotFoundException)
        {
            throw;
        }

        return NoContent();
    }
}