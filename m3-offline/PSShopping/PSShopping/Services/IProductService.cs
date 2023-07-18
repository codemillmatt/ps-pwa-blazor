using PSShopping.Shared;

namespace PSShopping.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts();
    }
}
