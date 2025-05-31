using Infrastructures.Features.Payments.Commands.CreatePayment;
using Microsoft.AspNetCore.Mvc;
using VNPAY.NET;
using VNPAY.NET.Utilities;
using MediatR;

namespace WebAPI.Controllers;

public class PaymentController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IVnpay _vnPay;

    public PaymentController(IMediator mediator, IVnpay vnPay)
    {
        _mediator = mediator;
        _vnPay = vnPay;
    }

    [HttpPost]
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