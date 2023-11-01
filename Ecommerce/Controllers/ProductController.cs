using BLL.DTO;
using Ecommerce.Models;
using Ecommerce.Models.DTO;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _repository;
        public ProductController(IProductService repository)
        {
            _repository = repository;
        }

        [HttpPost("addProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<ResponseDTO<ProductDTO>>> AddProduct(CreateProductDTO productDTO)
            {
            var product = await _repository.CreateProduct(productDTO);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ResponseDTO<List<ProductDTO>>> GetAllProducts()
        {
            List<ProductDTO> products = await _repository.GetAllProducts();
            var response = new ResponseDTO<List<ProductDTO>>
            {
                isSuccess = true,
                data = products
            };
            return response;
        }

        [AllowAnonymous]
        [HttpGet("getAProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ResponseDTO<ProductDTO>> GetAProduct(long id)
        {
            var product = await _repository.GetProductById(id);
            var response = new ResponseDTO<ProductDTO>
            {
                isSuccess = true,
                data = product
            };
            return response;
        }

        [HttpPut("updateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ResponseDTO<ProductDTO>> UpdateProduct(long id, CreateProductDTO updated)
        {
            var updatedProduct = await _repository.UpdateProduct(updated, id);
            var response = new ResponseDTO<ProductDTO>
            {
                isSuccess = true,
                data = updatedProduct
            };
            return response;
        }

        [HttpDelete("deleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ResponseDTO<bool>> DeleteProduct(long id)
        {
            bool product = await _repository.DeleteProductById(id);
            var response = new ResponseDTO<bool>
            {
                isSuccess = true,
                data = product
            };
            return response;
        }
    }
}
