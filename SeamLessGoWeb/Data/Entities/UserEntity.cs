using System.ComponentModel.DataAnnotations;

namespace SeamLessGoWeb.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string PasswordSalt { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public bool IsActive { get; set; }
        public string DisplayName { get; set; } = "";
        public int UserRoleID { get; set; }
        public Guid ClientID { get; set; }
    }
}
