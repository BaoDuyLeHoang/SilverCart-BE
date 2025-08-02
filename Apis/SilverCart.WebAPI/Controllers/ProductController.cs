using MediatR;
using Microsoft.AspNetCore.Mvc;
using Infrastructures.Features.Products.Commands.Create.CreateProduct;
using Infrastructures.Features.Products.Commands.Create.CreateItem;
using Infrastructures.Features.Products.Queries.GetAll;
using Infrastructures.Features.Products.Queries.GetById;
using Infrastructures.Commons.Paginations;
using Infrastructures.Features.Products.Commands.Add.AddProductImages;
using Infrastructures.Features.Products.Commands.Add.AddProductToCategories;
using Infrastructures.Features.Products.Commands.Delete.DeleteProductImage;
using Infrastructures.Features.Products.Commands.Delete.DeleteProductItems;
using Infrastructures.Features.Products.Commands.Update.UpdateProduct;
using Infrastructures.Features.Products.Commands.Update.UpdateProductImages;
using Infrastructures.Features.Products.Commands.Update.UpdateProductItems;
using Infrastructures.Features.Products.Commands.AddProductItems;
using Microsoft.AspNetCore.Authorization;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

 
        [HttpPost]
        [Authorize(Roles = "ShopOwner, Admin, SuperAdmin")]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "ShopOwner, Admin, SuperAdmin")]
        public async Task<ActionResult<bool>> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command with { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<GetAllProductsResponse>>> GetAllProducts([FromQuery] GetAllProductsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAllProductsResponse>> GetProductById(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdCommand(id));
            return Ok(result);
        }

        [HttpPost("images")]
        [Authorize(Roles = "ShopOwner, Admin, SuperAdmin")]
        public async Task<ActionResult<bool>> AddProductImage([FromForm] AddProductImagesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("images/{imageId}")]
        [Authorize(Roles = "ShopOwner, Admin, SuperAdmin")]
        public async Task<ActionResult<bool>> UpdateProductImage(
            [FromRoute] Guid imageId,
            [FromForm] UpdateProductImagesCommand command)
        {
            var updatedCommand = command with { ImageId = imageId };
            var result = await _mediator.Send(updatedCommand);
            return Ok(result);
        }

        [HttpDelete("images/{imageId}")]
        [Authorize(Roles = "ShopOwner, Admin, SuperAdmin")]
        public async Task<ActionResult<bool>> DeleteProductImage([FromRoute] Guid imageId)
        {
            var command = new DeleteProductImageCommand(imageId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{productId}/categories")]
        public async Task<ActionResult<bool>> AddProductToCategory(AddProductToCategoriesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{productId}/items")]
        public async Task<ActionResult<bool>> AddProductItem(AddProductItemsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{productId}/items/{itemId}")]
        public async Task<ActionResult<bool>> UpdateProductItem(UpdateProductItemsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{productId}/items/{itemId}")]
        public async Task<ActionResult<bool>> DeleteProductItem(DeleteProductItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }




        [HttpPost("items")]
        public async Task<ActionResult<Guid>> CreateItem([FromBody] CreateProductItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
