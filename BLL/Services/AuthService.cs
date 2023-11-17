using BLL.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<ApplicationUser> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                throw new Exception("Email address does not exist");
            }
            var response = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            var roles = await _userManager.GetRolesAsync(user);
            var jwtTokenId = $"JTI{Guid.NewGuid()}";
            var accessToken = _tokenService.CreateToken(user, roles);
            var refreshToken = _tokenService.CreateNewRefreshToken(user.Id, jwtTokenId);
            TokenDTO tokenDTO = new TokenDTO()
            {
                Token = accessToken,
                RefreshToken = refreshToken
            };
            if (response)
            {
                return user;
            }
            else
            {
                throw new Exception("The login details don't match");
            }

        }

        public async Task<bool> RegisterUser(CreateUserDTO createUserDTO, string roleName)
        {
            var email = await _userManager.FindByEmailAsync(createUserDTO.Email);
            if (email != null)
            {
                throw new Exception("Email already exists!");
            }
            else
            {
                var identityUser = new ApplicationUser()
                {
                    UserName = createUserDTO.Email,
                    Email = createUserDTO.Email,
                    FirstName = createUserDTO.FirstName,
                    LastName = createUserDTO.LastName

                };
                var result = await _userManager.CreateAsync(identityUser, createUserDTO.Password);
                if (result.Succeeded)
                {
                    var role = await _userManager.AddToRoleAsync(identityUser, roleName);
                    if (!role.Succeeded)
                    {
                        throw new Exception("Error in assigning role to user");

                    }

                }
                return true;
            }
        }
    }
}
