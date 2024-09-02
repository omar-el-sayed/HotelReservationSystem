using HotelReservationSystem.DTOs.Auth;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Services.Auth;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ResultViewModel<AuthViewModel>> RegisterAsync([FromBody] RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return ResultViewModel<AuthViewModel>.Failure(ErrorCode.FailedRegister, "");

            var result = await _authService.RegisterAsync(register.MapeOne<RegisterDto>());

            if (!result.IsAuthenticated)
                return ResultViewModel<AuthViewModel>.Failure(ErrorCode.FailedRegister, result.Message);

            return ResultViewModel<AuthViewModel>.Success(result.MapeOne<AuthViewModel>(), result.Message);
        }

        [HttpPost("login")]
        public async Task<ResultViewModel<AuthViewModel>> LoginAsync(TokenRequestViewModel token)
        {
            if (!ModelState.IsValid)
                return ResultViewModel<AuthViewModel>.Failure(ErrorCode.FailedLogin, "");

            var result = await _authService.GetTokenAsync(token.MapeOne<TokenRequestDto>());

            if (!result.IsAuthenticated)
                return ResultViewModel<AuthViewModel>.Failure(ErrorCode.FailedLogin, result.Message);

            return ResultViewModel<AuthViewModel>.Success(result.MapeOne<AuthViewModel>(), result.Message);
        }

        [HttpPost("addrole")]
        public async Task<ResultViewModel<string>> AssignRoleAsync(AddRoleViewModel roleVM)
        {
            if (!ModelState.IsValid)
                return ResultViewModel<string>.Failure(ErrorCode.FailedAddRole, "");

            var result = await _authService.AddRoleAsync(roleVM.MapeOne<AddRoleDto>());

            if (!string.IsNullOrEmpty(result))
                return ResultViewModel<string>.Failure(ErrorCode.FailedAddRole, result);

            return ResultViewModel<string>.Success("User assigned to role successfully", result);
        }
    }
}
