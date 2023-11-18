using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface ICustomerService
    {
      Task<CustomerDTO> CreateCustomer (CreateCustomerDTO customerDTO);
      Task<IEnumerable<CustomerDTO>> GetAllCustomers();
       Task<CustomerDTO> GetCustomerByID(int id);
    }
}
