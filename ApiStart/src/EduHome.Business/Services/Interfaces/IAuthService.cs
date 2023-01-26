using EduHome.Business.DTOs.Auth;

namespace EduHome.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto registerDto);
        Task<TokenResponseDto> LoginAsync(LoginDto loginDto);
    }
}
