namespace SeamLessGoWeb.Models.DownPayment
{
    public class DownPaymentListModel
    {
        public string DownPaymentID { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingAmount { get; set; }
        public byte PaymentMethod { get; set; }
        public byte PaymentStatus { get; set; }
        public bool IsVoided { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
