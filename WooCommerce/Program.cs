using Microsoft.EntityFrameworkCore;
using WooCommerce.Application.Services.Implementation;
using WooCommerce.Application.Services.Interfaces;
using WooCommerce.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ZohoOptions>(
    builder.Configuration.GetSection("Zoho"));

builder.Services.AddHttpClient<IZohoAuthService, ZohoAuthService>();
builder.Services.AddHttpClient<IZohoContactService, ZohoContactService>();
builder.Services.AddHttpClient<IZohoDealService, ZohoDealService>();

builder.Services.AddScoped<IZohoOrderService, ZohoOrderService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure the HTTP request pipeline.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WooCommerce API v1");
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
