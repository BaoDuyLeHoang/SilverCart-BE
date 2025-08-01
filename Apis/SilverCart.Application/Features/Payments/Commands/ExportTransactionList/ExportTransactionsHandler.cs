using ClosedXML.Excel;
using Core.Interfaces;
using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Payments.Commands.ExportTransactionList
{
    public sealed record ExportTransactionsQuery(
        Guid? WalletId,
        Guid? PaymentMethodId,
        Guid? PromotionId,
        Guid? CustomerUserId
    ) : IRequest<byte[]>;


    public class ExportTransactionsHandler(
        IUnitOfWork unitOfWork
    ) : IRequestHandler<ExportTransactionsQuery, byte[]>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<byte[]> Handle(ExportTransactionsQuery request, CancellationToken cancellationToken)
        {
            var histories = await _unitOfWork.PaymentHistoryRepository.GetAllAsync(
                predicate: _ => true,
                include: x => x
                    .Include(x => x.CustomerUser)
                    .Include(x => x.PaymentMethod)
                    .Include(x => x.Promotion)
                    .Include(x => x.Wallet)
            );

            var filtered = histories.AsQueryable();

            if (request.WalletId.HasValue)
                filtered = filtered.Where(x => x.WalletId == request.WalletId.Value);
            if (request.PaymentMethodId.HasValue)
                filtered = filtered.Where(x => x.PaymentMethodId == request.PaymentMethodId.Value);
            if (request.PromotionId.HasValue)
                filtered = filtered.Where(x => x.PromotionId == request.PromotionId.Value);
            if (request.CustomerUserId.HasValue)
                filtered = filtered.Where(x => x.CustomerUserId == request.CustomerUserId.Value);

            // Create Excel workbook
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Transactions");

            // Header row
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Amount";
            worksheet.Cell(1, 3).Value = "Created Date";
            worksheet.Cell(1, 4).Value = "Payment Method";
            worksheet.Cell(1, 5).Value = "Promotion";
            worksheet.Cell(1, 6).Value = "Customer Name";
            worksheet.Cell(1, 7).Value = "Note";
            worksheet.Cell(1, 8).Value = "Points";
            worksheet.Cell(1, 9).Value = "New Balance";
            worksheet.Cell(1, 10).Value = "Previous Balance";
            worksheet.Cell(1, 11).Value = "Status";

            int row = 2;

            foreach (var item in filtered)
            {
                worksheet.Cell(row, 1).Value = item.Id.ToString();
                worksheet.Cell(row, 2).Value = item.Amount;
                worksheet.Cell(row, 3).Value = item.CreationDate?.ToString("yyyy-MM-dd HH:mm:ss");
                worksheet.Cell(row, 4).Value = item.PaymentMethod?.Name;
                worksheet.Cell(row, 5).Value = item.Promotion?.Name ?? "No Promotion";
                worksheet.Cell(row, 6).Value = item.CustomerUser?.FullName;
                worksheet.Cell(row, 7).Value = item.Note;
                worksheet.Cell(row, 8).Value = item.Points;
                worksheet.Cell(row, 9).Value = item.NewBalance;
                worksheet.Cell(row, 10).Value = item.PreviousBalance;
                worksheet.Cell(row, 11).Value = item.Status.ToString();
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
