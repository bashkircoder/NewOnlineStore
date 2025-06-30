using Microsoft.Extensions.Options;
using OnlineStore.Application.Extensions;
using OnlineStore.Configuration;
using OnlineStore.Filters.ExceptionFilter;
using OnlineStore.Storage.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        var globalOptions = JsonOptionsSetup.GetGlobalJsonOptions();
        options.JsonSerializerOptions.Encoder = globalOptions.Encoder;
        options.JsonSerializerOptions.PropertyNamingPolicy = globalOptions.PropertyNamingPolicy;
    });

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("OnlineStoreConnectionString") ?? 
                       throw new ArgumentNullException("Строка подключения не найдена");

builder.Services
    .AddStorageDependency(connectionString)
    .AddApplicationDependency();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ErrorExceptionFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();