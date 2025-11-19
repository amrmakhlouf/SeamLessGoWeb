using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("CustomerTypes")]
    public class CustomerTypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerTypeID { get; set; }

        [Required]
        public string CustomerTypeTitle { get; set; }
    }

}
