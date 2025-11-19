using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("TransactionTypes")]

    public class TransactionTypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeID { get; set; }
        [Required]
        public string TransactionTypeTitle { get; set; }
    }
}
