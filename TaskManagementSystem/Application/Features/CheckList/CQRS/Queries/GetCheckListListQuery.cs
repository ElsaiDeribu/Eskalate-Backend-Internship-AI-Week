using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CheckList.DTOs;
using Application.Responses;
using MediatR;

namespace Application.Features.CheckList.CQRS.Queries
{
    public class GetCheckListListQuery : IRequest<Result<List<CheckListDto>>>
    {
    }
}
