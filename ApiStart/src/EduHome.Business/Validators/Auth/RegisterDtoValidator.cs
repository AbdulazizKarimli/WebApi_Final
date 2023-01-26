using EduHome.Business.DTOs.Auth;
using FluentValidation;

namespace EduHome.Business.Validators.Auth;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(u => u.Fullname)
            .MinimumLength(2)
            .MaximumLength(250);
        RuleFor(u => u.Username)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(100);
        RuleFor(u => u.Email)
            .NotEmpty()
            .NotNull()
            .MaximumLength(256)
            .EmailAddress();
        RuleFor(u => u.Password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(150);
    }
}