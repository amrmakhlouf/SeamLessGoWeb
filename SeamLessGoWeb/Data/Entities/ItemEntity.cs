using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    
        [Table("Items")]
        public class ItemEntity
        {
            [Key]
            public Guid ItemID { get; set; }

            [Required]
            public string ItemName { set; get; }
            public string ItemCode { set; get; }
            public string ItemDescription { set; get; }


            [ForeignKey("Category")]
            public int? CategoryID { set; get; }
            public CategoryEntity Category { set; get; }


            [ForeignKey("Supplier")]
            public int? SupplierID { set; get; }
            public SupplierEntity Supplier { set; get; }


            [ForeignKey("Brand")]
            public int? BrandID { set; get; }
            public BrandEntity Brand { set; get; }


            [ForeignKey("Tax")]
            public int? TaxID { set; get; }
            public TaxEntity Tax { set; get; }

            [Required]
            public bool IsActive { set; get; }
            [Required]
            public DateTime CreatedDate { set; get; }

            [Required]
            [ForeignKey("ItemType")]
            public int ItemTypeID { set; get; }
            public ItemTypeEntity ItemType { set; get; }

            [Required]
            public bool IsVoided { set; get; }

            [Required]
            public bool IsStockTracked { set; get; }

            [Required]
            public byte SyncStatus { get; set; }

            [Required]
            public DateTime LastModifiedUtc { get; set; }
        }
  }
