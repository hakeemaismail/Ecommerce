using AutoMapper;
using BLL.Services.IServices;
using DAL.DTO;
using DAL.Models;
using DAL.Repository.IRepository;

namespace BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CustomerDTO> CreateCustomer(CreateCustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                FullName = customerDTO.FullName,
            };
            _unitOfWork.Customer.Add(customer);
            await _unitOfWork.SaveAsync();

            CustomerDTO createdCustomer = _mapper.Map<CustomerDTO>(customer);
            return createdCustomer;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customerList = _unitOfWork.Customer.GetAll();
            IEnumerable<CustomerDTO> customers = _mapper.Map<List<CustomerDTO>>(customerList);
            return customers;
        }

        public async Task<CustomerDTO> GetCustomerByID(int id)
        {
            var result = _unitOfWork.Customer.GetById(id);
            CustomerDTO customer = _mapper.Map<CustomerDTO>(result);
            return customer;
        }
    }
}
