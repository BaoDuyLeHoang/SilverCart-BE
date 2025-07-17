using Infrastructures.Features.Conversations.Commands.Create;
using Infrastructures.Features.Conversations.Commands.Delete;
using Infrastructures.Features.Conversations.Queries.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationController(ISender sender) : BaseController
    {
        private readonly ISender _sender = sender;
        [HttpGet]
        public async Task<IActionResult> GetConversationById([FromQuery] GetConversationByUserIdQuery command)
        {
            var result = await _sender.Send(command);
            return result != null ? Ok(result) : NotFound(new { message = "No conversations found" });
        }
        [HttpPost]
        public async Task<IActionResult> CreateConversation(CreateConversationCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteConversation(Guid id)
        {
            var result = await _sender.Send(new DeleteConversationCommand(id));
            return Ok(result);
        }
    }
}
