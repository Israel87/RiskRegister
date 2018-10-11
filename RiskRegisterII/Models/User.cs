using System.Collections.Generic;

namespace RiskRegisterII.Models
{
    public class User : BaseEntity
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordRecovery { get; set; }
        public string ConfirmationToken { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsBlocked { get; set; }
        public virtual UserDetail UserDetail { get; set; }
        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}