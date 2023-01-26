using EduHome.Business.DTOs.Auth;
using EduHome.Core.Entities.Identity;

namespace EduHome.Business.HelperServices.Interfaces;

public interface ITokenHandler
{
    Task<TokenResponseDto> GenerateTokenAsync(AppUser user, int minute);
}
