﻿using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Products.Commands.ProductCreate;
using OnlineStore.Application.Products.Commands.ProductDelete;
using OnlineStore.Application.Products.Commands.ProductUpdate;
using OnlineStore.Application.Products.Queries.GetAllProducts;
using OnlineStore.Application.Products.Queries.GetDetailsProduct;
using OnlineStore.Application.Products.Queries.GetRangeProducts;
using OnlineStore.Application.RepositoryInterfaces;
using OnlineStore.Dto;
using OnlineStore.Mappers;
using OnlineStore.Storage.Exceptions;

namespace OnlineStore.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : Controller
{
    /// <summary>
    /// Gets the all products
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /api/products
    /// </remarks>
    /// <returns>Returns list of allProductDto</returns>
    /// <response code="200">Success</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetAllAsync([FromServices] GetAllProductsHandler getAllProductsHandler)
    {
        var products = await getAllProductsHandler.Execute();

        return Ok(products);
    }

    [HttpGet("{skip}/{take}")]
    public async Task<ActionResult> GetRangeAsync([FromServices] GetRangeProductsHandler getRangeProductsHandler, int skip, int take)
    {
        var products = await getRangeProductsHandler.Execute(skip, take);

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetByIdAsync([FromServices] GetDetailsProductHandler getDetailsProductHandler, int id)
    {
        var product = await getDetailsProductHandler.Execute(id);

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromServices] ProductCreateHandler productCreateHandler, ProductDto productDto)
    {
        try
        {
            var product = MapperProductDto.Map(productDto);

            await productCreateHandler.Execute(product);
        }
        catch (Exception)
        {
            throw;
        }

        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromServices] ProductDeleteHandler productDeleteHandler, int id)
    {
        try
        {
            await productDeleteHandler.Execute(id);
        }
        catch (NotFoundException)
        {
            throw;
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromServices] ProductUpdateHandler productUpdateHandler, ProductDto productDto)
    {
        try
        {
            var product = MapperProductDto.Map(productDto);
            await productUpdateHandler.Execute(product);
        }
        catch (NotFoundException)
        {
            throw;
        }

        return NoContent();
    }
}