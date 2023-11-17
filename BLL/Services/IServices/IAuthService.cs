using BLL.DTO;
using DAL.Models;

namespace BLL.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(CreateUserDTO createUserDTO, string roleName);
        Task<ApplicationUser> Login(LoginDTO loginDTO);
        
    }
}
