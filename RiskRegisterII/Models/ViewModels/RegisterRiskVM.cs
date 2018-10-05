using RiskRegister.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using static RiskRegister.CustomEnum.Enum;

namespace RiskRegisterII.Models.ViewModels
{
    public class RegisterRiskVM
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        [DisplayName("Risk Type")]
        public string RiskTypeName { get; set; }
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
