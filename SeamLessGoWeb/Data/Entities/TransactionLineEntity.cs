using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("TransactionLines")]
    public class TransactionLineEntity
    {
        [Key]
        public string TransactionLineID { get; set; }
        [Required]
        [ForeignKey("Transaction")]
        public string TransactionID { get; set; }
        public TransactionEntity Transaction { get; set; }

        [Required]
        [ForeignKey("Itempack")]
        public Guid ItemPackID { get; set; }
        public ItemPackEntity Itempack { set; get; }
        [Required]
        public decimal DiscountAmount { get; set; }
        [Required]
        public decimal DiscountPerc { get; set; }
        [Required]
        public decimal Bonus { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal ItemPrice { get; set; }
        [Required]
        public decimal FullPrice { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }

        public string Note { get; set; }

        [Required]
        public byte SyncStatus { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }
    }
}
