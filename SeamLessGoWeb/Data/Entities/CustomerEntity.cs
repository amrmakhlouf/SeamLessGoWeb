using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("Customers")]
    public class CustomerEntity
    {
        [Key]
        public Guid CustomerID { set; get; }
        public string CustomerCode { set; get; }

        [Required]
        public string FullName { set; get; }

        [ForeignKey("City")]
        public int? CityID { set; get; }
        public CityEntity City { set; get; }

        public string Address { set; get; }
        public string Email { set; get; }
        public string PhoneNumber1 { set; get; }
        public string PhoneNumber2 { set; get; }
        public double? Latitude { set; get; }
        public double? Longitude { set; get; }

        [Required]
        [ForeignKey("CustomerType")]
        public int CustomerTypeID { get; set; }
        public CustomerTypeEntity CustomerType { get; set; }

        [Required]
        public decimal CustomerBalance { get; set; }

        public decimal? AccountLimit { set; get; }

        [Required]
        [ForeignKey("CustomerGroup")]
        public int CustomerGroupID { set; get; }
        public CustomerGroupEntity CustomerGroup { set; get; }

        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedByUserID { set; get; }
        public UserEntity CreatedByUser { set; get; }

        [Required]
        public DateTime CreatedDate { set; get; }

        [Required]
        public bool IsActive { set; get; }
        public string CustomerNote { set; get; }

        [Required]
        public byte SyncStatus { get; set; }

        [Required]
        public bool IsVoided { get; set; }

        public bool? IsDefaultCustomer { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }

    }
}
