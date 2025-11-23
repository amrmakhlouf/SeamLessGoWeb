namespace SeamLessGoWeb.Models.Transactions
{
    public class TransactionListModel
    {
        public string TransactionID { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public bool IsVoided { get; set; }
        public bool IsTaxVisible { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
