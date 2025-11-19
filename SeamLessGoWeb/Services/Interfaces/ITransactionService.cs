using SeamLessGoWeb.Models;

namespace SeamLessGoWeb.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<List<TransactionListModel>> GetVisibleTransactionsAsync();
        Task VoidTransaction(string id);
    }
}
