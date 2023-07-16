using PSShopping.Shared;
using System.Net.Http.Json;

namespace PSShopping.Services
{
    public class ProductService
    {
        HttpClient client;
        // constructor with an injected http client
        public ProductService(HttpClient httpClient)
        {
            client = httpClient;
        }

        // get all products from web api
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await client.GetFromJsonAsync<Product[]>("products");
        }
    }
}
