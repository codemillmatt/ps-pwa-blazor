using PSShopping.Shared;

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

app.Run();