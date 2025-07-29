using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using Infrastructures.Features.Conversations.Commands.Create;
using Infrastructures.Features.Conversations.Commands.Delete;
using Infrastructures.Features.Conversations.Queries.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationController(ISender sender) : BaseController
    {
        private readonly ISender _sender = sender;
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách cuộc trò chuyện thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy cuộc trò chuyện")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetConversationById([FromQuery] GetConversationByUserIdQuery command)
        {
            var result = await _sender.Send(command);
            return result != null ? Ok(result) : NotFound(new { message = "No conversations found" });
        }
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo cuộc trò chuyện thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> CreateConversation(CreateConversationCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Xóa cuộc trò chuyện thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy cuộc trò chuyện")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> DeleteConversation(Guid id)
        {
            var result = await _sender.Send(new DeleteConversationCommand(id));
            return Ok(result);
        }
    }
}
