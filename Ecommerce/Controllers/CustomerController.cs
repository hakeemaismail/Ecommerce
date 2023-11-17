using BLL.Services.IServices;
using DAL.DTO;
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
        public async Task<CustomerDTO> AddCustomer(CreateCustomerDTO customerDTO)
        {
            var customer = await _customerService.CreateCustomer(customerDTO);
            return customer;
        }

        [HttpGet("ViewAllCustomers")]
        public async Task<IEnumerable<CustomerDTO>> ViewAllCustomers()
        {
            var customerList = await _customerService.GetAllCustomers();
            return customerList;
        }

        [HttpGet("GetCustomerByID")]
        public async Task<CustomerDTO> GetCustomerByID(int ID)
        {
            var customer = await _customerService.GetCustomerByID(ID);
            return customer;
        }
    }
}
