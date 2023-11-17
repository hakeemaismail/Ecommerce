using BLL.DTO;
using DAL.Models;
using System.Security.Claims;

namespace BLL.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, IList<string> roles);
        Task<TokenDTO> RefreshAccessToken(TokenDTO tokenDTO);
        string CreateNewRefreshToken(string userId, string tokenId);

    }
}
