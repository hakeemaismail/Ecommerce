using BLL.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> Login(LoginDTO loginDTO)
        {
            var userExists = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (userExists == null)
            {
                throw new Exception("Email address does not exist");
            }
            var response = await _userManager.CheckPasswordAsync(userExists, loginDTO.Password);
            if (response)
            {
                return userExists;
            }
            else
            {
                throw new Exception("The login details don't match");
            }
            
        }

        public async Task<bool> RegisterUser(CreateUserDTO createUserDTO)
        {
            var emailExists = await _userManager.FindByEmailAsync(createUserDTO.Email);
            if (emailExists != null)
            {
                throw new Exception("Email already exists!");
            }
            else
            {
                var identityUser = new ApplicationUser()
                {
                    Email = createUserDTO.Email,
                    FirstName = createUserDTO.FirstName,
                    LastName = createUserDTO.LastName

                };
                var result = _userManager.CreateAsync(identityUser);
                return result.IsCompletedSuccessfully;
            }
        }
    }
}
