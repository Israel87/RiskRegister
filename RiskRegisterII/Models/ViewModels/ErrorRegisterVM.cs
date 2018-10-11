using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RiskRegister.CustomEnum.Enum;

namespace RiskRegisterII.Models.ViewModels
{
    public class ErrorRegisterVM
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string ErrorType { get; set; }
        public string Narration { get; set; }
        public string Officer { get; set; }
        public ProcessStatus Status { get; set; } 
        public ErrorRegisterStatus ErrorStatus { get; set; }
        public string Remark { get; set; }
        public string RiskType { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
       
    }
}
