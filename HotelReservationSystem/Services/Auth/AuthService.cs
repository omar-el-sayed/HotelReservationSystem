using HotelReservationSystem.DTOs.Auth;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelReservationSystem.Services.Auth
{
    public class AuthService(UserManager<User> _userManager) : IAuthService
    {
        public async Task<AuthDto> RegisterAsync(RegisterDto register)
        {
            if (await _userManager.FindByEmailAsync(register.Email) is not null)
                return new AuthDto { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(register.Username) is not null)
                return new AuthDto { Message = "Username is already registered!" };

            var user = register.MapeOne<User>();
            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                string errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }

                return new AuthDto { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "Customer");
        }
    }
}
