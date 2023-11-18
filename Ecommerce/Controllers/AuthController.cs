using BLL.DTO;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IAuthService authService, ITokenService tokenService, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateUser(CreateUserDTO user, string roleName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var result = await _authService.RegisterUser(user, roleName);

                if (result)
                {
                    return Ok("success");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> GetNewTokenFromRefreshToken(TokenDTO tokenDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var refreshedToken = await _tokenService.RefreshAccessToken(tokenDTO);

                    if (refreshedToken == null || string.IsNullOrEmpty(refreshedToken.Token))
                    {
                        return BadRequest();
                    }

                    return Ok(refreshedToken);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var result = await _authService.Login(login);

                if (result != null)
                {
                    var roles = await _userManager.GetRolesAsync(result);
                    var response = new TokenDTO
                    {
                        Token = _tokenService.CreateToken(result, roles),
                        RefreshToken = _tokenService.CreateNewRefreshToken(result.Id, Guid.NewGuid().ToString())
                    }; 

                    return Ok(response);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
