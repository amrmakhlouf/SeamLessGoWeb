using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("Brands")]
    public class BrandEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandID { set; get; }

        [Required]
        public string BrandName { set; get; }

        public string BrandDescription { set; get; }
    }
}
