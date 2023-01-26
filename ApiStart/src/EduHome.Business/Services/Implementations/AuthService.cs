using EduHome.Business.DTOs.Auth;
using EduHome.Business.Exceptions;
using EduHome.Business.HelperServices.Interfaces;
using EduHome.Business.Services.Interfaces;
using EduHome.Core.Entities.Identity;
using EduHome.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduHome.Business.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ITokenHandler _tokenHandler;

    public AuthService(UserManager<AppUser> userManager
        , IConfiguration configuration
        , ITokenHandler tokenHandler)
    {
        _userManager = userManager;
        _configuration = configuration;
        _tokenHandler = tokenHandler;
    }

    public async Task<TokenResponseDto> LoginAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.Username);
        if (user is null) throw new AuthFailException("Username or password incorrect!");

        var check = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if(!check) throw new AuthFailException("Username or password incorrect!");

        //Create Jwt
        var tokenResponse = await _tokenHandler.GenerateTokenAsync(user, 1);

        return tokenResponse;
    }

    public async Task RegisterAsync(RegisterDto registerDto)
    {
        AppUser user = new()
        {
            Fullname = registerDto.Fullname,
            UserName = registerDto.Username,
            Email = registerDto.Email,
        };

        var identityResult = await _userManager.CreateAsync(user, registerDto.Password);
        if (!identityResult.Succeeded)
        {
            string errors = String.Empty;
            int count = 0;
            foreach (var error in identityResult.Errors)
            {
                errors += count != 0 ?  $",{error.Description}" : $"{error.Description}";
                count++;
            }

            throw new UserCreateFailException(errors);
        }

        var result = await _userManager.AddToRoleAsync(user, Roles.Member.ToString());
        if (!result.Succeeded)
        {
            string errors = String.Empty;
            int count = 0;
            foreach (var error in result.Errors)
            {
                errors += count != 0 ? $",{error.Description}" : $"{error.Description}";
                count++;
            }

            throw new RoleCreateFailException(errors);
        }
    }
}
