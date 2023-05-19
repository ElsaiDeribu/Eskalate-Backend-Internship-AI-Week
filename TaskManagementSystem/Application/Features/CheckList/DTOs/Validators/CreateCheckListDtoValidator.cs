using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.CheckList.DTOs.Validators
{
    internal class CreateCheckListDtoValidator : AbstractValidator<CreateCheckListDto>
    {

        public CreateCheckListDtoValidator()
        {
            Include(new ICheckListDtoValidator());

        }
    }
}