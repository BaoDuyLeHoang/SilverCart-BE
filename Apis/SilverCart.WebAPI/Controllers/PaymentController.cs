using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using Infrastructures.Commons.Exceptions;
using Infrastructures.Features.PaymentHistories.Queries.GetAllPaymentHistories;
using Infrastructures.Features.Payments.Commands.CreatePayment;
using Infrastructures.Features.Payments.Commands.ExportTransactionList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
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
        public ActionResult<bool> IPNReturn()
        {
            if (Request.QueryString.HasValue)
            {
                try
                {
                    var paymentResult = _vnPay.GetPaymentResult(Request.Query);
                    if (paymentResult.IsSuccess)
                    {
                        return Ok(true);
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

        [HttpGet("transaction/{id:guid}")]
        public async Task<ActionResult<GetPaymentHistoryDetailsResponse>> GetPaymentByOrderId([FromRoute] Guid id)
        {
            try
            {
                var response = await _mediator.Send(new GetPaymentHistoryDetailsQuery(id));
                return Ok(response);
            }
            catch (AppExceptions ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<GetAllPaymentHistoriesResponse>> GetAllPayments([FromQuery] GetAllPaymentHistoriesQuery query)
        {
            try
            {
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("export-transactions")]
        public async Task<IActionResult> ExportTransactionsToExcel([FromQuery] ExportTransactionsQuery query)
        {
            var fileBytes = await _mediator.Send(query);
            var fileName = $"Transaction_History_{DateTime.UtcNow:yyyyMMdd_HHmmss}.xlsx";
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }


    }
}