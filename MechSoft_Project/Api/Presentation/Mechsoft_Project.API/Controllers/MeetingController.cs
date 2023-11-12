using Mechsoft_Project.Application.Features.Commands.CreateMeeting;
using Mechsoft_Project.Application.Features.Commands.DeleteMeeting;
using Mechsoft_Project.Application.Features.Commands.UpdateMeeting;
using Mechsoft_Project.Application.Features.Queries.GetMeeting;
using Mechsoft_Project.Application.Features.Queries.GetOneMeeting;
using Mechsoft_Project.Common.Models.Commands;
using Mechsoft_Project.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mechsoft_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MeetingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var meetings = await _mediator.Send(new GetMeetingQuery());

            return Ok(meetings);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var meeting = await _mediator.Send(new GetOneMeetingQuery(id));
            return Ok(meeting); 
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateMeetingCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateMeetingCommand command)
        {
            var meeting = await _mediator.Send(command);
            return Ok(meeting);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new DeleteMeetingCommand() { Id = id }); 
            return NoContent();
        }
    }
}
