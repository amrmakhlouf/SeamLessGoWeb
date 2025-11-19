using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("Orders")]
    public class OrderEntity
    {
        [Key]
        public string OrderID { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }
        public CustomerEntity Customer { set; get; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Required]
        [ForeignKey("OrderType")]
        public int OrderTypeID { get; set; }
        public OrderTypeEntity OrderType { set; get; }

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

        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedByUserID { get; set; }
        public UserEntity CreatedByUser { set; get; }

        public int? RouteID { get; set; }

        [Required]
        public bool IsVoided { get; set; }
        public string Note { get; set; }

        [ForeignKey("SourceOrder")]
        public string SourceOrderID { get; set; }
        public OrderEntity SourceOrder { set; get; }


        [Required]
        public byte SyncStatus { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }



    }
}
