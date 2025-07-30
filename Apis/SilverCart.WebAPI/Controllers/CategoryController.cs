using Infrastructures.Features.Categories.Commands.Create.CreateCategory;
using Infrastructures.Features.Categories.Commands.Delete.DeleteCategory;
using Infrastructures.Features.Categories.Commands.Update.UpdateCategory;
using Infrastructures.Features.Categories.Queries.GetAll;
using Infrastructures.Features.Categories.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<Guid>> CreateCategory([FromBody] CreateCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCategory([FromBody] UpdateCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<bool>> DeleteCategory(Guid id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAllCategoryResponse>> GetCategoryById(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<GetAllCategoryResponse>>> GetAllCategories([FromQuery] GetAllCategoriesQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
