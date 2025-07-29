using Infrastructures.Features.Categories.Commands.Create.CreateCategory;
using Infrastructures.Features.Categories.Commands.Delete.DeleteCategory;
using Infrastructures.Features.Categories.Commands.Update.UpdateCategory;
using Infrastructures.Features.Categories.Queries.GetAll;
using Infrastructures.Features.Categories.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Infrastructures.Commons.Paginations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo danh mục thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Cập nhật danh mục thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy danh mục")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Xóa danh mục thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy danh mục")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy thông tin danh mục thành công", typeof(GetAllCategoryResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy danh mục")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách danh mục thành công", typeof(PagedResult<GetAllCategoryResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoriesQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
