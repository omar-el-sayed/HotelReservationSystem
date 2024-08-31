using HotelReservationSystem.DTOs.Auth;

namespace HotelReservationSystem.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthDto> RegisterAsync(RegisterDto register);
    }
}
