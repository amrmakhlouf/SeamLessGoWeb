using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    [Table("Routes")]
    public class RouteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RouteID { get; set; }

        [Required]
        [ForeignKey("Plan")]
        public int PlanID { get; set; }
        public PlanEntity Plan { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }
        public UserEntity User { set; get; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public byte Status { get; set; }
    }
}
