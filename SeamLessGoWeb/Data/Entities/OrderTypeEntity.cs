using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("OrderTypes")]
    public class OrderTypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderTypeID { get; set; }

        [Required]
        public string OrderTypeTitle { get; set; }
    }
}
