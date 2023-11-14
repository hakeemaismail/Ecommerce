using DAL.Models;

namespace BLL.Services
{
    public interface ITokenService
    {
       string CreateToken(ApplicationUser user);
    }
}
