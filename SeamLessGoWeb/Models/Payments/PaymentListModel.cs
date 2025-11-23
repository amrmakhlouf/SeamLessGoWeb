namespace SeamLessGoWeb.Models.Payments
{
    public class PaymentListModel
    {
        public string PaymentID { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public decimal Amount { get; set; }
        public byte PaymentMethod { get; set; }
        public byte PaymentStatus { get; set; }
        public bool IsVoided { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
