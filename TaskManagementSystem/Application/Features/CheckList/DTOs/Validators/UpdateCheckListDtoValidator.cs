

using FluentValidation;

namespace Application.Features.CheckList.DTOs.Validators
{
    public class UpdateCheckListDtoValidator : AbstractValidator<UpdateCheckListDto>
    {
        public UpdateCheckListDtoValidator()
        {
            Include(new ICheckListDtoValidator());
        }
    }
}