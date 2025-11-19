using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("Categories")]
    public class CategoryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { set; get; }
        [Required]
        public string CategoryName { set; get; }
        public string CategoryDescription { set; get; }

        [Required]
        public byte SyncStatus { get; set; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }

    }
}
