using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Task.DTOs;
using MediatR;
using Application.Responses;

namespace Application.Features.Task.CQRS.Commands
{
    public class CreateTaskCommand : IRequest<Result<int>>

    {
        public CreateTaskDto TaskDto {get;set;}
    }
}
