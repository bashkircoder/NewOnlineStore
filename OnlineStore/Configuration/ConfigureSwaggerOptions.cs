using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace OnlineStore.Configuration;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        options.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Version = "v1",
                Title = $"OnlineShop API v1",
                Description = "A simple web service that provides a RESTful API for managing products and product categories.",
                Contact = new OpenApiContact
                {
                    Name = " Artem Astakhov",
                    Email = "astahov.invest@gmail.com",
                    Url = new Uri("https://t.me/billionariesclub")
                },
            });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    }
}