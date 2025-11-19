using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("Transactions")]
    public class TransactionEntity
    {
        [Key]
        public string TransactionID { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }
        public CustomerEntity Customer { set; get; }

        [Required]
        public DateTime TransactionDate { get; set; }

        public DateTime? UpdatedDate { get; set; }


        [Required]
        [ForeignKey("TransactionType")]
        public int TransactionTypeID { get; set; }
        public TransactionTypeEntity TransactionType { set; get; }


        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public decimal GrossAmount { get; set; }
        [Required]
        public decimal TotalRemainingAmount { get; set; }
        [Required]
        public decimal DiscountAmount { get; set; }
        [Required]
        public decimal DiscountPerc { get; set; }
        [Required]
        public decimal NetAmount { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public decimal TaxPerc { get; set; }

        [Required]
        public byte Status { get; set; }

        public byte? SalesMode { get; set; }


        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedByUserID { get; set; }
        public UserEntity CreatedByUser { set; get; }

        public int? RouteID { get; set; }
        public RouteEntity Route { set; get; }

        [Required]
        [ForeignKey("Currency")]
        public int CurrencyID { get; set; }
        public CurrencyEntity Currency { set; get; }

        [Required]
        public bool IsVoided { get; set; }
        public string Note { get; set; }


        [ForeignKey("SourceTransaction")]
        public string SourceTransactionID { get; set; }
        public TransactionEntity SourceTransaction { set; get; }


        [ForeignKey("SourceOrder")]
        public string SourceOrderID { get; set; }
        public OrderEntity SourceOrder { set; get; }

        [Required]
        public byte SyncStatus { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }
        public List<TransactionLineEntity> TransactionLines { get; set; }
    }
}
