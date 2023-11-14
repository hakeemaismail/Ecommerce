using BLL.DTO;
using Ecommerce.Models.DTO;

namespace Ecommerce.Repositories
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int productId);
        Task<ProductDTO> CreateProduct(CreateProductDTO createProductDTO);
        Task<ProductDTO> UpdateProduct(CreateProductDTO updatedProduct, int id);
        Task<bool> DeleteProductById(int productId);
    }
}
