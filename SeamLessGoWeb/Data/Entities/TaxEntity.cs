using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("Taxes")]
    public class TaxEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaxID { set; get; }
        [Required]
        public string TaxName { set; get; }
        [Required]
        public float TaxRate { set; get; }
    }
}
