using SeamLessGoWeb.Models.Transactions;

namespace SeamLessGoWeb.Models.Transactions
{
    public class TransactionDetailModel
    {
        public TransactionListModel Transaction { get; set; }
        public List<TransactionLineModel> Lines { get; set; }
    }
}
