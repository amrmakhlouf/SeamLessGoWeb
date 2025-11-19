using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("Currencies")]
    public class CurrencyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrencyID { set; get; }

        [Required]
        public string CurrencyName { set; get; }
        [Required]
        public string CurrencyAbb { set; get; }
        [Required]
        public string CurrencySymbol { set; get; }
        public float? ExchangeRateUSD { set; get; }
    }
}
