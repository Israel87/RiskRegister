using static RiskRegisterII.Models.CustomEnum;

namespace RiskRegisterII.Models
{
    public class UserDetail : BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}