using EduHome.Business.DTOs.Auth;
using FluentValidation;

namespace EduHome.Business.Validators.Auth;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(u => u.Username)
        .NotEmpty()
        .NotNull()
        .MinimumLength(2)
        .MaximumLength(100);
        RuleFor(u => u.Password)
        .NotNull()
        .NotEmpty()
        .MinimumLength(6)
        .MaximumLength(150);
    }
}
