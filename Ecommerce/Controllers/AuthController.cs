using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateUser(CreateUserDTO user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var result = await _authService.RegisterUser(user);

                if (result)
                {

                    return Ok("success");
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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

                    var response = new LoginResponseDTO
                    {
                        Email = result.Email,
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        Jwt = _tokenService.CreateToken(result)
                    };
                    return Ok(response);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
