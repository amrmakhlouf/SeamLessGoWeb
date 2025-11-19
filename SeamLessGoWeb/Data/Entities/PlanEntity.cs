using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("Plans")]
    public class PlanEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlanID { get; set; }
        [Required]
        public string PlanName { get; set; }
        public string PlanDesc { set; get; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Required]
        [ForeignKey("CreatedByUser")]
        public int CreatedByUserID { get; set; }
        public UserEntity CreatedByUser { get; set; }

        [ForeignKey("PlanUser")]
        public int? PlanUserID { get; set; }
        public UserEntity PlanUser { get; set; }


    }
}
