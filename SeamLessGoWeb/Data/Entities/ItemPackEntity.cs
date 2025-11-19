using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("ItemPacks")]
    public class ItemPackEntity
    {
        [Key]
        public Guid ItemPackID { set; get; }

        [Required]
        [ForeignKey("Item")]
        public Guid ItemID { set; get; }
        public ItemEntity Item { set; get; }

        [Required]
        public float Equivalency { set; get; }
        [Required]
        public bool IsWeightable { set; get; }


        [ForeignKey("Unit")]
        public int? UnitID { set; get; }
        public UnitEntity Unit { set; get; }

        public string BarCode { set; get; }
        [Required]
        public decimal Price { set; get; }
        [Required]
        public decimal Cost { set; get; }

        [Required]
        public bool Enabled { set; get; }

        [Required]
        public bool IsVoided { set; get; }

        public string PrimaryImage { set; get; }


        [Required]
        public byte SyncStatus { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }
    }
}
