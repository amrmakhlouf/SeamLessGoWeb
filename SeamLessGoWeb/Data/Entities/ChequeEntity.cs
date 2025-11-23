using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("Cheques")]
    public class ChequeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChequeID { set; get; }
        [Required]
        public required string ChequeNumber { set; get; }
        [Required]
        public DateTime ReceivingDate { set; get; }
        [Required]
        public required string ChequeOwner { set; get; }
        [Required]
        public decimal Amount { set; get; }

        [Required]
        [ForeignKey("Currency")]
        public int CurrencyID { set; get; }
        public required CurrencyEntity Currency { set; get; }

        [Required]
        [ForeignKey("Bank")]
        public int BankID { set; get; }
        public BankEntity Bank { set; get; } = null!;
        [Required]
        public DateTime DueDate { set; get; }
        [Required]
        public bool IsThirdParty { set; get; }
        public string? Note { set; get; }

        [Required]
        public bool Bounced { set; get; }

        [ForeignKey("Customer")]
        public Guid? CustomerID { set; get; }
        public CustomerEntity? Customer { set; get; }

        [ForeignKey("Supplier")]
        public int? SupplierID { set; get; }
        public SupplierEntity? Supplier { set; get; }

        [Required]
        public bool IsVoided { set; get; }

        [Required]
        public DateTime LastModifiedUtc { get; set; }

    }
}
