

using FluentValidation;

namespace Application.Features.Task.DTOs.Validators
{
    public class UpdateTaskDtoValidator : AbstractValidator<UpdateTaskDto>
    {
        public UpdateTaskDtoValidator()
        {
            Include(new ITaskDtoValidator());
        }
    }

}
