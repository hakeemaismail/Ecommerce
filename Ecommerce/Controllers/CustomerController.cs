using BLL.Services.IServices;
using DAL.DTO;
using Ecommerce.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("AddCustomer")]
        public async Task<ResponseDTO<CustomerDTO>> AddCustomer(CreateCustomerDTO customerDTO)
        {
            var customer = await _customerService.CreateCustomer(customerDTO);
            var response = new ResponseDTO<CustomerDTO>
            {
                isSuccess = true,
                message = "Customer has been added",
                code = StatusCodes.Status200OK,
                data = customer

            };
            return response;
        }

        [HttpGet("ViewAllCustomers")]
        public async Task<ResponseDTO<IEnumerable<CustomerDTO>>> ViewAllCustomers()
        {
            var customerList = await _customerService.GetAllCustomers();
            var response = new ResponseDTO<IEnumerable<CustomerDTO>>
            {
                isSuccess = true,
                message = "Customer list",
                code = StatusCodes.Status200OK,
                data = customerList

            };
            return response;
        }

        [HttpGet("GetCustomerByID")]
        public async Task<ResponseDTO<CustomerDTO>> GetCustomerByID(int ID)
        {
            var customer = await _customerService.GetCustomerByID(ID);
            var response = new ResponseDTO<CustomerDTO>
            {
                isSuccess = true,
                message = "Customer fetched from database",
                code = StatusCodes.Status200OK,
                data = customer

            };
            return response;
        }
    }
}
