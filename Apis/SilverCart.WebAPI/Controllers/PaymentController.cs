using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using Infrastructures.Features.Payments.Commands.CreatePayment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using VNPAY.NET;
using VNPAY.NET.Utilities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IVnpay _vnPay;

        public PaymentController(IMediator mediator, IVnpay vnPay)
        {
            _mediator = mediator;
            _vnPay = vnPay;
        }

        [Authorize]
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo thanh toán thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentCommand command)
        {
            try
            {
                var paymentUrl = await _mediator.Send(command);
                return Created(paymentUrl, paymentUrl);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (NotImplementedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ipn")]
        [SwaggerResponse(StatusCodes.Status200OK, "Xử lý callback từ VNPay thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy thông tin thanh toán")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public IActionResult IPNReturn()
        {
            if (Request.QueryString.HasValue)
            {
                try
                {
                    var paymentResult = _vnPay.GetPaymentResult(Request.Query);
                    if (paymentResult.IsSuccess)
                    {
                        return Ok();
                    }
                    return BadRequest("Thanh toán thất bại");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return NotFound("Không tìm thấy thông tin thanh toán.");
        }

        [HttpGet("callback")]
        [SwaggerResponse(StatusCodes.Status200OK, "Xử lý return từ VNPay thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy thông tin thanh toán")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public ActionResult<string> Callback()
        {
            if (Request.QueryString.HasValue)
            {
                try
                {
                    var paymentResult = _vnPay.GetPaymentResult(Request.Query);
                    var resultDescription = $"{paymentResult.PaymentResponse.Description}. {paymentResult.TransactionStatus.Description}.";

                    if (paymentResult.IsSuccess)
                    {
                        return Ok(resultDescription);
                    }
                    return BadRequest(resultDescription);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return NotFound("Không tìm thấy thông tin thanh toán.");
        }
    }
}