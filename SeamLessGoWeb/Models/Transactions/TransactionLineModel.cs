namespace SeamLessGoWeb.Models.Transactions
{
    public class TransactionLineModel
    {
        public string TransactionLineID { get; set; }
        public string TransactionID { get; set; }
        public string ItemName { get; set; }
        public string PackName { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal TotalPrice { get; set; }
        public string Note { get; set; }
    }
}
