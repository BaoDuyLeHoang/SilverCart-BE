using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using Infrastructures.Features.Messages.Commands.Create;
using Infrastructures.Features.Messages.Commands.Recall;
using Infrastructures.Features.Messages.Commands.Update;
using Infrastructures.Features.Messages.Queries.GetByConversationId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI;

[ApiController]
[Route("api/[controller]")]
public class MessageController(ISender sender) : BaseController
{
    private readonly ISender _sender = sender;
    [HttpGet("conversations")]
    [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách tin nhắn thành công")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy tin nhắn")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> GetMessagesByConversationId([FromQuery] GetMessageByConversationIdQuery command)
    {
        var result = await _sender.Send(command);
        return result != null ? Ok(result)
            : NotFound(new { Message = "Messages not found for the specified conversation." });
    }
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status200OK, "Gửi tin nhắn thành công")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> CreateMessage(CreateMessageCommand command)
    {
        var result = await _sender.Send(command);
        return result != null ? Ok(result)
            : BadRequest(new { Message = "Failed to create message." });
    }
    [HttpPatch("update")]
    [SwaggerResponse(StatusCodes.Status200OK, "Cập nhật tin nhắn thành công")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy tin nhắn")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> UpdateMessage([FromBody] UpdateMessageCommand command)
    {
        var result = await _sender.Send(command);
        return result != null ? Ok(result)
            : BadRequest(new { Message = "Failed to update message" });
    }
    [HttpPatch("/recall")]
    [SwaggerResponse(StatusCodes.Status200OK, "Thu hồi tin nhắn thành công")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy tin nhắn")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> RecallMessage([FromBody] RecallMessageCommand command)
    {
        var result = await _sender.Send(command);
        return result != null ? Ok(result)
            : BadRequest(new { Message = "Failed to recall message" });
    }
}
