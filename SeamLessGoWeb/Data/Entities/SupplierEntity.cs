using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("Suppliers")]
    public class SupplierEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { set; get; }
        [Required]
        public string SupplierName { set; get; }
        public string SupplierCode { set; get; }
        public string SupplierDescription { set; get; }
        public string Address { set; get; }
        public string MobileNumber { set; get; }
        public string PhoneNumber { set; get; }

        [Required]
        public decimal SupplierBalance { set; get; }

        [ForeignKey("City")]
        public int? CityID { set; get; }
        public CityEntity City { set; get; }

        public string SupplierNote { set; get; }


        [Required]
        public byte SyncStatus { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }

    }
}
