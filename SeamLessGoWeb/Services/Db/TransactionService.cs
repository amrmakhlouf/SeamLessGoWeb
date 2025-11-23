using Microsoft.EntityFrameworkCore;
using SeamLessGoWeb.Data;
using SeamLessGoWeb.Data.Entities;
using SeamLessGoWeb.Services.Interfaces;
using SeamLessGoWeb.Models;
using SeamLessGoWeb.Models.Transactions;

namespace SeamLessGoWeb.Services.Db
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _db;

        public TransactionService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<TransactionListModel>> GetVisibleTransactionsAsync(bool isAdmin)
        {
            var query = _db.Transactions
                .Where(t => !t.IsVoided);

            // If NOT admin, only show transactions where IsTaxVisible = false
            if (!isAdmin)
            {
                query = query.Where(t => !t.IsTaxVisible);
            }

            return await query
                .Include(t => t.Customer)
                .Include(t => t.CreatedByUser)
                .Select(t => new TransactionListModel
                {
                    TransactionID = t.TransactionID,
                    CustomerName = t.Customer.FullName,
                    EmployeeName = t.CreatedByUser.UserName,
                    NetAmount = t.NetAmount,
                    TotalAmount = t.TotalAmount,
                    RemainingAmount = t.TotalRemainingAmount,
                    IsVoided = t.IsVoided,
                    TransactionDate = t.TransactionDate,
                    IsTaxVisible = t.IsTaxVisible
                })
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<List<TransactionListModel>> GetTransactionsByTypeAsync(int transactionTypeId, bool isAdmin)
        {
            var query = _db.Transactions
                .Where(t => !t.IsVoided && t.TransactionTypeID == transactionTypeId);

            // If NOT admin, filter out transactions where IsTaxVisible = true
            if (!isAdmin)
            {
                query = query.Where(t => !t.IsTaxVisible);
            }

            return await query
                .Include(t => t.Customer)
                .Include(t => t.CreatedByUser)
                .Select(t => new TransactionListModel
                {
                    TransactionID = t.TransactionID,
                    CustomerName = t.Customer.FullName,
                    EmployeeName = t.CreatedByUser.UserName,
                    NetAmount = t.NetAmount,
                    TotalAmount = t.TotalAmount,
                    RemainingAmount = t.TotalRemainingAmount,
                    IsVoided = t.IsVoided,
                    TransactionDate = t.TransactionDate,
                    IsTaxVisible = t.IsTaxVisible
                })
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<TransactionDetailModel> GetTransactionDetailAsync(string transactionId)
        {
            var transaction = await _db.Transactions
                .Where(t => t.TransactionID == transactionId)
                .Include(t => t.Customer)
                .Include(t => t.CreatedByUser)
                .Select(t => new TransactionListModel
                {
                    TransactionID = t.TransactionID,
                    CustomerName = t.Customer.FullName,
                    EmployeeName = t.CreatedByUser.UserName,
                    NetAmount = t.NetAmount,
                    TotalAmount = t.TotalAmount,
                    RemainingAmount = t.TotalRemainingAmount,
                    IsVoided = t.IsVoided,
                    TransactionDate = t.TransactionDate,
                    IsTaxVisible = t.IsTaxVisible
                })
                .FirstOrDefaultAsync();

            if (transaction == null)
                return null;

            var lines = await GetTransactionLinesAsync(transactionId);

            return new TransactionDetailModel
            {
                Transaction = transaction,
                Lines = lines
            };
        }

        public async Task<List<TransactionLineModel>> GetTransactionLinesAsync(string transactionId)
        {
            return await _db.TransactionLines
                .Where(tl => tl.TransactionID == transactionId)
                .Include(tl => tl.Itempack)
                    .ThenInclude(ip => ip.Item)
                .Include(tl => tl.Itempack)
                    .ThenInclude(ip => ip.Unit)
                .Select(tl => new TransactionLineModel
                {
                    TransactionLineID = tl.TransactionLineID,
                    TransactionID = tl.TransactionID,
                    ItemName = tl.Itempack.Item.ItemName,
                    PackName = tl.Itempack.Unit.UnitName,
                    Quantity = tl.Quantity,
                    ItemPrice = tl.ItemPrice,
                    DiscountAmount = tl.DiscountAmount,
                    DiscountPerc = tl.DiscountPerc,
                    TotalPrice = tl.TotalPrice,
                    Note = tl.Note
                })
                .ToListAsync();
        }

        public async Task VoidTransaction(string id)
        {
            var transaction = await _db.Transactions.FindAsync(id);
            if (transaction == null) return;

            transaction.IsVoided = true;
            transaction.LastModifiedUtc = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> UpdateTransaction(string transactionId, TransactionListModel model)
        {
            var transaction = await _db.Transactions.FindAsync(transactionId);
            if (transaction == null) return false;

            transaction.NetAmount = model.NetAmount;
            transaction.TotalAmount = model.TotalAmount;
            transaction.TotalRemainingAmount = model.RemainingAmount;
            transaction.LastModifiedUtc = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task ToggleTaxVisibility(string transactionId, bool isTaxVisible)
        {
            var transaction = await _db.Transactions.FindAsync(transactionId);
            if (transaction == null) return;

            transaction.IsTaxVisible = isTaxVisible;
            transaction.LastModifiedUtc = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }
    }
}