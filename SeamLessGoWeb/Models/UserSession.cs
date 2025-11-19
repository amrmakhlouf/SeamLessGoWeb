namespace SeamLessGoWeb.Models
{
    public class UserSession
    {
        public int UserID { get; set; }
        public string DisplayName { get; set; } = "";
        public string UserName { get; set; } = "";
        public int UserRoleID { get; set; }
        public Guid ClientID { get; set; }
    }
}
