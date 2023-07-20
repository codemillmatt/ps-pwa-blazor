using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using PSShopping.Shared;
using System.Security.Claims;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// add in distributed cache
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

var allProducts = new []
{
    "Hiking boots", "Tent", "Jacket", "Hiking poles"
};

app.MapGet("/products", () =>
{
    // propulate a list of Product class from the allProducts array
    var products = allProducts.Select(p => new Product { ProductName = p });
    return products;
})
.WithName("GetAllProducts");

app.MapPut("/notifications/subscribe", (IDistributedCache cache, NotificationSubscription sub) =>
{
    var json = JsonSerializer.Serialize(sub);

    // in production we'd be storing to a persistent store and we'd also be using a unique identifier for the user
    // here we're just going to assume only one user is using the app
    cache.SetString("subscription", json);
    
    // store the subscription in the database
    return Results.Ok();
});

app.MapGet("/notifications/get", (IDistributedCache cache) =>
{
    var json = cache.GetString("subscription");
    if (!string.IsNullOrEmpty(json))
        return Results.Ok(JsonSerializer.Deserialize<NotificationSubscription>(json));
    else
        return Results.NotFound();
});

app.Run();