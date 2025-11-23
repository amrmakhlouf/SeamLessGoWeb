using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("DownPayments")]
    public class DownPaymentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DownPaymentID { get; set; } = null!;

        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }
        public CustomerEntity Customer { get; set; } = null!;

        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedByUserID { get; set; }
        public UserEntity CreatedByUser { set; get; } = null!;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal RemainingAmount { get; set; }

        [Required]
        [ForeignKey("Currency")]
        public int CurrencyID { get; set; }
        public CurrencyEntity Currency { set; get; } = null!;

        [Required]
        public byte PaymentMethod { get; set; }
        [Required]
        public byte PaymentStatus { get; set; }

        public int? RouteID { get; set; }


        [ForeignKey("CreatedFromPayment")]
        public string? CreatedFromPaymentID { get; set; }
        public PaymentEntity? CreatedFromPayment { set; get; }

        [ForeignKey("CreatedFromTransaction")]
        public string? CreatedFromTransactionID { get; set; }
        public TransactionEntity? CreatedFromTransaction { set; get; }

        [ForeignKey("Cheque")]
        public int? ChequeID { get; set; }
        public ChequeEntity? Cheque { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }

        [Required]
        public bool IsVoided { get; set; }

        [Required]
        public bool IsTaxVisible { get; set; }
    }
}
