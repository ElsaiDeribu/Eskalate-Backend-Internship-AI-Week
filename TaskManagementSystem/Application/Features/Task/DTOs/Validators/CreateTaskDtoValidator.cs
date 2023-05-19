﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
