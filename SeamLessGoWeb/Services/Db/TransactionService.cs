using SeamLessGoWeb.Data;
using SeamLessGoWeb.Models;
using SeamLessGoWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SeamLessGoWeb.Services.Db
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _db;

        public TransactionService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<TransactionListModel>> GetVisibleTransactionsAsync()
        {
            return await _db.Transactions
                .Where(t => !t.IsVoided)
                .Select(t => new TransactionListModel
                {
                    TransactionID = t.TransactionID,
                    CustomerName = t.Customer.FullName,
                    EmployeeName = t.CreatedByUser.UserName,
                    NetAmount = t.NetAmount,
                    TotalAmount = t.TotalAmount,
                    RemainingAmount = t.TotalRemainingAmount,
                    IsVoided = t.IsVoided,
                    TransactionDate = t.TransactionDate
                })
                .ToListAsync();
        }

        public async Task VoidTransaction(string id)
        {
            var transaction = await _db.Transactions.FindAsync(id);
            if (transaction == null) return;

            transaction.IsVoided = true;
            await _db.SaveChangesAsync();
        }
    }
}
