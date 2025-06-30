using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Application.ProductCategories.Queries.GetAllProductCategories;
using OnlineStore.Application.Products.Commands.ProductCreate;
using System.Reflection;
using OnlineStore.Application.ProductCategories.Commands.ProductCategoryCreate;
using OnlineStore.Application.ProductCategories.Commands.ProductCategoryDelete;
using OnlineStore.Application.ProductCategories.Commands.ProductCategoryUpdate;
using OnlineStore.Application.ProductCategories.Queries.GetDetailsProductCategory;
using OnlineStore.Application.ProductCategories.Queries.GetRangeProductsCategories;
using OnlineStore.Application.Products.Commands.ProductDelete;
using OnlineStore.Application.Products.Commands.ProductUpdate;
using OnlineStore.Application.Products.Queries.GetAllProducts;
using OnlineStore.Application.Products.Queries.GetDetailsProduct;
using OnlineStore.Application.Products.Queries.GetRangeProducts;

namespace OnlineStore.Application.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplicationDependency(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);

        services.AddScoped<ProductCreateHandler>();
        services.AddScoped<ProductUpdateHandler>();
        services.AddScoped<ProductDeleteHandler>();
        
        services.AddScoped<GetAllProductsHandler>();
        services.AddScoped<GetDetailsProductHandler>();
        services.AddScoped<GetRangeProductsHandler>();
        
        services.AddScoped<CreateProductCategoryHandler>();
        services.AddScoped<UpdateProductCategoryHandler>();
        services.AddScoped<DeleteProductCategoryHandler>();
        
        services.AddScoped<GetAllProductCategoriesHandler>();
        services.AddScoped<GetDetailsProductCategoryHandler>();
        services.AddScoped<GetRangeProductCategoriesHandler>();

        return services;
    }
}