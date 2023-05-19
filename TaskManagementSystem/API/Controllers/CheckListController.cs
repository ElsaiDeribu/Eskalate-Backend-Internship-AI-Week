
using Application.Features.CheckList.CQRS.Commands;
using Application.Features.CheckList.CQRS.Queries;
using Application.Features.CheckList.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckListController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CheckListController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return HandleResult(await _mediator.Send(new GetCheckListListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetCheckListDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCheckListDto createCheckListDto)
        {
            return HandleResult(await _mediator.Send(new CreateCheckListCommand { CheckListDto = createCheckListDto }));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateCheckListDto updateCheckListDto)
        {
            return HandleResult(await _mediator.Send(new UpdateCheckListCommand { CheckListDto = updateCheckListDto }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return HandleResult(await _mediator.Send(new DeleteCheckListCommand { Id = id }));
        }



    }
}