using Infrastructures.Commons;
using Infrastructures.Features.Products.Commands.Add.AddProductImages;
using Infrastructures.Features.Products.Commands.Add.AddProductToCategories;
using Infrastructures.Features.Products.Commands.Add.AddStockToStoreProductItems;
using Infrastructures.Features.Products.Commands.AddProductItems;
using Infrastructures.Features.Products.Commands.Create.CreateItem;
using Infrastructures.Features.Products.Commands.Create.CreateProduct;
using Infrastructures.Features.Products.Commands.Create.CreateVariant;
using Infrastructures.Features.Products.Commands.Delete.DeleteProductImage;
using Infrastructures.Features.Products.Commands.Delete.DeleteProductItems;
using Infrastructures.Features.Products.Commands.Delete.DeleteProductVariant;
using Infrastructures.Features.Products.Commands.Update.UpdateProduct;
using Infrastructures.Features.Products.Commands.Update.UpdateProductImages;
using Infrastructures.Features.Products.Commands.Update.UpdateProductItems;
using Infrastructures.Features.Products.Commands.Update.UpdateProductVariant;
using Infrastructures.Features.Products.Queries.GetAll;
using Infrastructures.Features.Products.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdCommand(id));
            return Ok(result);
        }
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> AddProductImage(AddProductImagesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{productId}/images")]
        public async Task<IActionResult> UpdateProductImages(UpdateProductImagesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{productId}/images")]
        public async Task<IActionResult> DeleteProductImage(DeleteProductImageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("{productId}/categories")]
        public async Task<IActionResult> AddProductToCategory(AddProductToCategoriesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("{productId}/variants")]
        public async Task<IActionResult> AddProductVariantToProduct(AddProductItemsToVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{productId}/variants/{variantId}")]
        public async Task<IActionResult> UpdateProductVariant(UpdateProductVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{productId}/variants/{variantId}")]
        public async Task<IActionResult> DeleteProductVariant(DeleteProductVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("{productId}/variants/{variantId}/items")]
        public async Task<IActionResult> AddProductItemToVariant(AddProductItemsToVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{productId}/variants/{variantId}/items/{itemId}")]
        public async Task<IActionResult> UpdateProductItem(UpdateProductItemsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{productId}/variants/{variantId}/items/{itemId}")]
        public async Task<IActionResult> DeleteProductItem(DeleteProductItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch");
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("variants")]
        public async Task<IActionResult> CreateVariant([FromBody] CreateProductVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("items")]
        public async Task<IActionResult> CreateItem([FromBody] CreateProductItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
