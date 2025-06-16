//using Infrastructures.Features.Messages.Commands.Create;
//using Infrastructures.Features.Messages.Commands.Recall;
//using Infrastructures.Features.Messages.Commands.Update;
//using Infrastructures.Features.Messages.Queries.GetByConversationId;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using WebAPI.Controllers;

//namespace WebAPI;

//[ApiController]
//[Route("api/[controller]")]
//public class MessageController(ISender sender) : BaseController
//{
//    private readonly ISender _sender = sender;
//    [HttpGet("conversations")]
//    public async Task<IActionResult> GetMessagesByConversationId([FromQuery] GetMessageByConversationIdQuery command)
//    {
//        var result = await _sender.Send(command);
//        return result != null ? Ok(result)
//            : NotFound(new { Message = "Messages not found for the specified conversation." });
//    }
//    [HttpPost]
//    public async Task<IActionResult> CreateMessage(CreateMessageCommand command)
//    {
//        var result = await _sender.Send(command);
//        return result != null ? Ok(result)
//            : BadRequest(new { Message = "Failed to create message." });
//    }
//    [HttpPatch("update")]
//    public async Task<IActionResult> UpdateMessage([FromBody] UpdateMessageCommand command)
//    {
//        var result = await _sender.Send(command);
//        return result != null ? Ok(result)
//            : BadRequest(new { Message = "Failed to update message" });
//    }
//    [HttpPatch("/recall")]
//    public async Task<IActionResult> RecallMessage([FromBody] RecallMessageCommand command)
//    {
//        var result = await _sender.Send(command);
//        return result != null ? Ok(result)
//            : BadRequest(new { Message = "Failed to recall message" });
//    }
//}
