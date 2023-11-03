using AutoMapper;
using BLL.DTO;
using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            var productsToReturn = _mapper.Map<List<ProductDTO>>(products);
            return productsToReturn;
        }

        public async Task<ProductDTO> GetProductById(long productId)
        {
            var product = await _context.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            var returnProduct = _mapper.Map<ProductDTO>(product);
            return returnProduct;
        }

        public async Task<ProductDTO> CreateProduct(CreateProductDTO createProductDTO)
        {
            ProductDTO productDTO = new ProductDTO();
            if(createProductDTO is null)
            {
                return productDTO;
            }

            Product product = _mapper.Map<Product>(createProductDTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

           productDTO = _mapper.Map<ProductDTO>(product);
           return productDTO;

        }

        public async Task<ProductDTO> UpdateProduct(CreateProductDTO updatedProduct, long id)
        {
           ProductDTO productDTO = new ProductDTO();
           var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
          if(product != null)
            {
                //product = _mapper.Map<Product>(updatedProduct);
                //await _context.SaveChangesAsync();
                //productDTO = _mapper.Map<ProductDTO>(product);

                _mapper.Map(updatedProduct, product);

                // Save the changes to the database
                await _context.SaveChangesAsync();

                // Map the updated product back to a DTO
                productDTO = _mapper.Map<ProductDTO>(product);
            }
            return productDTO;
        }

        public async Task<bool> DeleteProductById(long productId)
        {
            var product = await _context.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            if(product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
