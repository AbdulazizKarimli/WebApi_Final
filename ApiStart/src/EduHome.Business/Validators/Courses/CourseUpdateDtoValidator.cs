using EduHome.Business.DTOs.Courses;
using FluentValidation;

namespace EduHome.Business.Validators.Courses;

public class CourseUpdateDtoValidator: AbstractValidator<CourseUpdateDto>
{
    public CourseUpdateDtoValidator()
    {
        /*RuleFor(c => c.Id).Custom((Id, context) =>
        {
            if(!int.TryParse(Id.ToString(), out var id))
            {
                context.AddFailure("Please enter correct format.");
            }
        });*/
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required")
            .NotNull().WithMessage("Name is required")
            .MaximumLength(150).WithMessage("Maximum length: 150 symbol");
        RuleFor(c => c.Description)
            .MaximumLength(500)
            .WithMessage("Maximum length: 500 symbol");
        RuleFor(c => c.Image)
            .MaximumLength(500)
            .WithMessage("Maximum length: 500 symbol");
    }
}
