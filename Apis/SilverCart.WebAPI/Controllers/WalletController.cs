using Infrastructures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SilverCart.Application.Features.Wallet.Queries.GetWalletBalance;
using SilverCart.Application.Features.Wallet.Queries.GetWalletHistory;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : BaseController
    {
        private readonly IMediator _mediator;

        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lấy thông tin ví tiền của người dùng
        /// </summary>
        /// <returns>Thông tin ví tiền</returns>
        [HttpGet("balance")]
        public async Task<ActionResult<GetWalletBalanceResponse>> GetWalletBalance()
        {
            var result = await _mediator.Send(new GetWalletBalanceQuery());
            return Ok(result);
        }

        /// <summary>
        /// Lấy lịch sử giao dịch ví tiền
        /// </summary>
        /// <param name="query">Tham số phân trang</param>
        /// <returns>Danh sách lịch sử giao dịch</returns>
        [HttpGet("history")]
        public async Task<ActionResult<GetWalletHistoryResponse>> GetWalletHistory([FromQuery] GetWalletHistoryQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}