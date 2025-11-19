using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("OrderLines")]
    public class OrderLineEntity
    {
        [Key]
        public string OrderLineID { get; set; }

        [Required]
        [ForeignKey("Order")]
        public string OrderID { get; set; }
        public OrderEntity Order { set; get; }

        [Required]
        [ForeignKey("ItemPack")]
        public Guid ItemPackID { get; set; }
        public ItemPackEntity ItemPack { set; get; }

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
