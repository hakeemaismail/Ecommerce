using BLL.DTO;
using Ecommerce.Models.DTO;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("addProduct")]
        public async Task<ActionResult<ResponseDTO<ProductDTO>>> AddProduct(CreateProductDTO productDTO)
        {
            var product = await _productService.CreateProduct(productDTO);
            var response = new ResponseDTO<ProductDTO>
            {
                isSuccess = true,
                message = "Product added successfully",
                code = StatusCodes.Status200OK,
                data = product
            };
            return response;
        }

        [AllowAnonymous]
        [HttpGet("getAllProducts")]
        public async Task<ResponseDTO<List<ProductDTO>>> GetAllProducts()
        {
            List<ProductDTO> products = await _productService.GetAllProducts();
            var response = new ResponseDTO<List<ProductDTO>>
            {
                isSuccess = true,
                data = products
            };
            return response;
        }

        [AllowAnonymous]
        [HttpGet("getAProduct")]
        public async Task<ResponseDTO<ProductDTO>> GetAProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            var response = new ResponseDTO<ProductDTO>
            {
                isSuccess = true,
                data = product
            };
            return response;
        }

        [HttpPut("updateProduct")]
        public async Task<ResponseDTO<ProductDTO>> UpdateProduct(int id, CreateProductDTO updated)
        {
            var updatedProduct = await _productService.UpdateProduct(updated, id);
            var response = new ResponseDTO<ProductDTO>
            {
                isSuccess = true,
                data = updatedProduct
            };
            return response;
        }

        [HttpDelete("deleteProduct")]
        public async Task<ResponseDTO<bool>> DeleteProduct(int id)
        {
            bool product = await _productService.DeleteProductById(id);
            var response = new ResponseDTO<bool>
            {
                isSuccess = true,
                data = product
            };
            return response;
        }
    }
}
