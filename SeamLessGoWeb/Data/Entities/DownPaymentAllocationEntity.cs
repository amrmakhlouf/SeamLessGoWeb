using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("DownPaymentAllocations")]
    [PrimaryKey(nameof(PaymentID), nameof(DownPaymentID))]
    public class DownPaymentAllocationEntity
    {
        [ForeignKey("Payment")]
        public string PaymentID { get; set; } = null!;
        public PaymentEntity Payment { set; get; } = null!;

        [ForeignKey("DownPayment")]
        public string DownPaymentID { get; set; } = null!;
        public DownPaymentEntity DownPayment { set; get; } = null!;

        [Required]
        public decimal AllocatedAmount { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }
    }

}
