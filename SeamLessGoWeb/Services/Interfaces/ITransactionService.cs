using SeamLessGoWeb.Models.Transactions;


namespace SeamLessGoWeb.Services.Interfaces
{
    public interface ITransactionService
    {

        Task<List<TransactionListModel>> GetVisibleTransactionsAsync(bool isAdmin);
        Task<List<TransactionListModel>> GetTransactionsByTypeAsync(int transactionTypeId, bool isAdmin);
        Task<TransactionDetailModel> GetTransactionDetailAsync(string transactionId);
        Task<List<TransactionLineModel>> GetTransactionLinesAsync(string transactionId);
        Task VoidTransaction(string id);
        Task<bool> UpdateTransaction(string transactionId, TransactionListModel model);
        Task ToggleTaxVisibility(string transactionId, bool isTaxVisible);

    }
}
