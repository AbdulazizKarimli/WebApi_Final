using EduHome.Business.DTOs.Courses;
using FluentValidation;

namespace EduHome.Business.Validators.Courses;


public class CoursePostDtoValidator : AbstractValidator<CoursePostDto>
{
    public CoursePostDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required")
            .NotNull().WithMessage("Name is required")
            .MaximumLength(150).WithMessage("Maximum length: 150 symbol");
        RuleFor(c => c.Description)
            .MaximumLength(500)
            .WithMessage("Maximum length: 500 symbol");
       
    }
}
