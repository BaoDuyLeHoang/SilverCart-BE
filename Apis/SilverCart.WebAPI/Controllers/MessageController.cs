using MediatR;
using Microsoft.AspNetCore.Mvc;
using SilverCart.Application.Interfaces;
using SilverCart.WebAPI.Controllers;
using Infrastructures.Features.Messages.Queries.GetByConversationId;
using Infrastructures.Features.Messages.Commands.Create;
using Infrastructures.Features.Messages.Commands.Update;
using Infrastructures.Features.Messages.Commands.Recall;
using SilverCart.Application.Interfaces.Repositories;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController(ISender sender) : BaseController
{
    private readonly ISender _sender = sender;

    [HttpGet("conversations")]
    public async Task<ActionResult<List<MessageDto>>> GetMessagesByConversationId([FromQuery] GetMessageByConversationIdQuery command)
    {
        var result = await _sender.Send(command);
        return result != null ? Ok(result)
            : NotFound(new { Message = "Messages not found for the specified conversation." });
    }

    [HttpPost]
    public async Task<ActionResult<CreateMessageResponse>> CreateMessage(CreateMessageCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }

    [HttpPatch("update")]
    public async Task<ActionResult<UpdateMessageResponse>> UpdateMessage([FromBody] UpdateMessageCommand command)
    {
        var result = await _sender.Send(command);
        return result;
    }

    [HttpPatch("/recall")]
    public async Task<ActionResult<RecallMessageResponse>> RecallMessage([FromBody] RecallMessageCommand command)
    {
        var result = await _sender.Send(command);
        return result;
    }
}
