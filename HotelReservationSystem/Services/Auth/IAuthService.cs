using HotelReservationSystem.DTOs.Auth;

namespace HotelReservationSystem.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthDto> RegisterAsync(RegisterDto register);
        Task<AuthDto> GetTokenAsync(TokenRequestDto token);
        Task<string> AddRoleAsync(AddRoleDto role);
    }
}
