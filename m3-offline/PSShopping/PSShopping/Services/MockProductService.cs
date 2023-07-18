using PSShopping.Shared;

namespace PSShopping.Services
{
    public class MockProductService : IProductService
    {
        public async Task<IEnumerable<Product>> GetProducts()
        {
            await Task.CompletedTask;

            // return a list of products
            var products = new List<Product>
            {
                new Product { ProductName = "Hiking boots" },
                new Product { ProductName = "Tent" },
                new Product { ProductName = "Jacket" },
                new Product { ProductName = "Hiking poles" }
            };

            return products;
        }
    }
}
