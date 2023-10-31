using BLL.DTO;
using Ecommerce.Models;
using Ecommerce.Models.DTO;

namespace Ecommerce.Repositories
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(long productId);
        Task<ProductDTO> CreateProduct(CreateProductDTO createProductDTO);
        Task<ProductDTO> UpdateProduct(CreateProductDTO updatedProduct, long id);
        Task<bool> DeleteProductById(long productId);
    }
}
