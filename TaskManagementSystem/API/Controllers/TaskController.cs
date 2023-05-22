
using Application.Features.Task.CQRS.Commands;
using Application.Features.Task.CQRS.Queries;
using Application.Features.Task.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : BaseApiController
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<ActionResult> Get()
        {

            return HandleResult(await _mediator.Send(new GetTaskListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetTaskDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTaskDto createTaskDto)
        {
            return HandleResult(await _mediator.Send(new CreateTaskCommand { TaskDto = createTaskDto }));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateTaskDto updateTaskDto)
        {
            return HandleResult(await _mediator.Send(new UpdateTaskCommand { TaskDto = updateTaskDto }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return HandleResult(await _mediator.Send(new DeleteTaskCommand { Id = id }));
        }




    }
}