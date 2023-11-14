using AutoMapper;
using BLL.DTO;
using DAL.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.DTO;

namespace Ecommerce.Repositories
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var products = _unitOfWork.Products.GetAll();
            var productsToReturn = _mapper.Map<List<ProductDTO>>(products);
            return productsToReturn;
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            var product = _unitOfWork.Products.GetById(productId);
            var returnProduct = _mapper.Map<ProductDTO>(product);
            return returnProduct;
        }

        public async Task<ProductDTO> CreateProduct(CreateProductDTO createProductDTO)
        {
            ProductDTO productDTO = new ProductDTO();
            if (createProductDTO is null)
            {
                return productDTO;
            }

            Product product = _mapper.Map<Product>(createProductDTO);
            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveAsync();

            productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;

        }

        public async Task<ProductDTO> UpdateProduct(CreateProductDTO updatedProduct, int id)
        {
            ProductDTO productDTO = new ProductDTO();

            var product = _unitOfWork.Products.GetById(id);
            if (product != null)
            {
                _mapper.Map(updatedProduct, product);
                await _unitOfWork.SaveAsync();
                productDTO = _mapper.Map<ProductDTO>(product);
            }
            return productDTO;
        }

        public async Task<bool> DeleteProductById(int productId)
        {
            var product = _unitOfWork.Products.GetById(productId);

            if (product != null)
            {
                _unitOfWork.Products.Remove(product);
                await _unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
