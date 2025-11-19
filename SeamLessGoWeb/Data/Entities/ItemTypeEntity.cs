using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("ItemTypes")]
    public class ItemTypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemTypeID { get; set; }

        [Required]
        public string ItemTypeTitle { get; set; }
    }
}
