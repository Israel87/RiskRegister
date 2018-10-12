using RiskRegister.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using static RiskRegister.CustomEnum.Enum;

namespace RiskRegisterII.Models
{
    public class RegisterRisk
    {
        public int Id { get; set; }
        [DisplayName("Activity")]
        public string Activity { get; set; }
        [DisplayName("Risk Type")]
        public int RiskTypeId { get; set; }
        public string RiskName { get; set; }
        [DisplayName("Inherent Risk")]
        public string InherentRisk { get; set; }
        [DisplayName("Mitigants")]
        public string Mitigants { get; set; }
        [DisplayName("Logged By")]
        public string LoggedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public ProcessStatus Status { get; set; }

    }
}
