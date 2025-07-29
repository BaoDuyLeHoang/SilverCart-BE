using MediatR;
using Microsoft.AspNetCore.Mvc;
using Infrastructures.Features.Products.Commands.Create.CreateProduct;
using Infrastructures.Features.Products.Commands.Create.CreateItem;
using Infrastructures.Features.Products.Commands.Create.CreateVariant;
using Infrastructures.Features.Products.Queries.GetAll;
using Infrastructures.Features.Products.Queries.GetById;
using Infrastructures.Commons.Paginations;
using Infrastructures.Features.Products.Commands.Add.AddProductImages;
using Infrastructures.Features.Products.Commands.Add.AddProductToCategories;
using Infrastructures.Features.Products.Commands.Delete.DeleteProductImage;
using Infrastructures.Features.Products.Commands.Delete.DeleteProductVariant;
using Infrastructures.Features.Products.Commands.Delete.DeleteProductItems;
using Infrastructures.Features.Products.Commands.Update.UpdateProduct;
using Infrastructures.Features.Products.Commands.Update.UpdateProductImages;
using Infrastructures.Features.Products.Commands.Update.UpdateProductVariant;
using Infrastructures.Features.Products.Commands.Update.UpdateProductItems;
using Infrastructures.Features.Products.Commands.AddProductItems;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo sản phẩm thành công", typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách sản phẩm thành công", typeof(PagedResult<GetAllProductsResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy thông tin sản phẩm thành công", typeof(GetAllProductsResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdCommand(id));
            return Ok(result);
        }

        [HttpPost("{productId}/images")]
        [SwaggerResponse(StatusCodes.Status200OK, "Thêm ảnh sản phẩm thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> AddProductImage(AddProductImagesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{productId}/images")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cập nhật ảnh sản phẩm thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> UpdateProductImages(UpdateProductImagesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{productId}/images")]
        [SwaggerResponse(StatusCodes.Status200OK, "Xóa ảnh sản phẩm thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> DeleteProductImage(DeleteProductImageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{productId}/categories")]
        [SwaggerResponse(StatusCodes.Status200OK, "Thêm sản phẩm vào danh mục thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm hoặc danh mục")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> AddProductToCategory(AddProductToCategoriesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("{productId}/variants")]
        [SwaggerResponse(StatusCodes.Status200OK, "Thêm biến thể sản phẩm thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> AddProductVariantToProduct(AddProductItemsToVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{productId}/variants/{variantId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cập nhật biến thể sản phẩm thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm hoặc biến thể")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> UpdateProductVariant(UpdateProductVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{productId}/variants/{variantId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Xóa biến thể sản phẩm thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm hoặc biến thể")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> DeleteProductVariant(DeleteProductVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("{productId}/variants/{variantId}/items")]
        [SwaggerResponse(StatusCodes.Status200OK, "Thêm mục sản phẩm vào biến thể thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm hoặc biến thể")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> AddProductItemToVariant(AddProductItemsToVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{productId}/variants/{variantId}/items/{itemId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cập nhật mục sản phẩm thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm, biến thể hoặc mục")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> UpdateProductItem(UpdateProductItemsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{productId}/variants/{variantId}/items/{itemId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Xóa mục sản phẩm thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm, biến thể hoặc mục")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> DeleteProductItem(DeleteProductItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cập nhật sản phẩm thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
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
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo biến thể sản phẩm thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> CreateVariant([FromBody] CreateProductVariantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("items")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo mục sản phẩm thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> CreateItem([FromBody] CreateProductItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
