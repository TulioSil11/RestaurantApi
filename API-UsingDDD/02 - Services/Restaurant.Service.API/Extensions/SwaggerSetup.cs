using Microsoft.OpenApi.Models;

namespace Restaurant.Service.API.Extensions;
public static class SwaggerSetup
{
    public static void AddServiceSwagger(this WebApplicationBuilder builder) 
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void AddSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }   
}
