using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using Infrastructures.Features.Payments.Commands.CreatePayment;
using Infrastructures.Features.Payments.Commands.AddToWallet;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<string>> CreatePayment([FromBody] CreatePaymentCommand command)
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
        public async Task<ActionResult<AddToWalletResponse>> IPNReturn([FromQuery] IQueryCollection query)
        {
            if (Request.QueryString.HasValue)
            {
                var paymentResult = _vnPay.GetPaymentResult(query);
                var command = new AddToWalletCommand(paymentResult.PaymentResponse);
                var result = await _mediator.Send(command);
                return result;
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
}