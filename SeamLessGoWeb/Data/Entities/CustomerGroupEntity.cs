using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("CustomerGroups")]
    public class CustomerGroupEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerGroupID { set; get; }
        [Required]
        public string CustomerGroupName { set; get; }
        [Required]
        public DateTime CreatedDate { set; get; }
        [Required]
        public int? NumberOfCustomers { set; get; }
    }
}
