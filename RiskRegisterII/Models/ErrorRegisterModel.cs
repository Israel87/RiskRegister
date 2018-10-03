using RiskRegister.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static RiskRegister.CustomEnum.Enum;

namespace RiskRegisterII.Models
{
    public class ErrorRegisterModel
    {
        public int Id { get; set; }

        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }
        [DisplayName("Error Type")]
        public string ErrorType { get; set; }
        [DisplayName("Narration")]
        public string Narration { get; set; }
        [DisplayName("Officer")]
        public string Officer { get; set; }    
        public ProcessStatus Status { get; set; }
        [DisplayName("Resolved / Not Resolved")]
        public ErrorRegisterStatus ErrorStatus { get; set; }
        [DisplayName("Remark")]
        public string Remark { get; set; }
        public int RiskTypeId { get; set; }
        public RiskType RiskType { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
