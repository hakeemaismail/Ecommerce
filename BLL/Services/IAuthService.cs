using BLL.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(CreateUserDTO createUserDTO);
        Task<ApplicationUser> Login(LoginDTO loginDTO);
    }
}
