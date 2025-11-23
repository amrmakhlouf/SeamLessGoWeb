using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("PaymentAllocations")]
    [PrimaryKey(nameof(PaymentID), nameof(TransactionID))]
    public class PaymentAllocationEntity
    {

        [ForeignKey("Payment")]
        public string PaymentID { get; set; } = null!;
        public PaymentEntity Payment { set; get; } = null!;


        [ForeignKey("Transaction")]
        public string TransactionID { get; set; } = null!;
        public TransactionEntity Transaction { set; get; } = null!;

        [Required]
        public decimal AllocatedAmount { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }
    }
}
