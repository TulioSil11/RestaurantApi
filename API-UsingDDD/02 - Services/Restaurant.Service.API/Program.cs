using Restaurant.Service.API.Extensions;
using Restaurant.Infra.IoC;
using Restaurant.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.AddServiceSwagger();
builder.Services.InsertDependencies(builder.Configuration);
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingEntities()));

var app = builder.Build();

app.AddSwaggerConfiguration();
app.UseCors(x => x.AllowAnyOrigin());

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

