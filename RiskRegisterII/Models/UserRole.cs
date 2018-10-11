namespace RiskRegisterII.Models
{
    public class UserRole : BaseEntity
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}