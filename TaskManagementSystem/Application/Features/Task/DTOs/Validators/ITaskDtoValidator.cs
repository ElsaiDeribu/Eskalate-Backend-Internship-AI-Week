
using FluentValidation;

namespace Application.Features.Task.DTOs.Validators
{
    public class ITaskDtoValidator : AbstractValidator<ITaskDto>
    {

        public ITaskDtoValidator()
        {

        RuleFor(t => t.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


        RuleFor(t => t.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        }

      
    }
}