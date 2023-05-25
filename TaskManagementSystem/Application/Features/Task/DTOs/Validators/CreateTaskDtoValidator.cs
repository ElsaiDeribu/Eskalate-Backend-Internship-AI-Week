
using FluentValidation;

namespace Application.Features.Task.DTOs.Validators
{
    public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
    {

        public CreateTaskDtoValidator()
        {

            Include(new ITaskDtoValidator());

        }
    }
}
