using BLL.DTO;
using DAL.Models;

namespace BLL.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(CreateUserDTO createUserDTO);
        Task<ApplicationUser> Login(LoginDTO loginDTO);
    }
}
