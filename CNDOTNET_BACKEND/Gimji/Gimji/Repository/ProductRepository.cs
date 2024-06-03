using Gimji.DTO;
using Gimji.Models;

namespace Gimji.Repository
{
    public interface ProductRepository
    {
        Task<bool> DoesItemExist(string id);
        Task<IEnumerable<Product>> GetAllProduct(string? search, double? from, double? to, string? sortBy,int? limit , int? page = 1);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryCode, string? search, double? from, double? to, string? sortBy, int? limit, int? page = 1);
        Task<Product> GetProductById(string id);
        Task<Product> GetProductByName(string name);
        Task AddProduct(Product product);
        Task UpdateProduct(string id, ProductDTO productDTO);
        Task DeleteProduct(string id);
        Task<string> saveImages(IFormFile imageFile);
    }
}
