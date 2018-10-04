using RiskRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Models
{
    public class RegisterRisk
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        //public int RiskId { get; set; }
        public string RiskBucket { get; set; }
        public string InherentRisk { get; set; }
        public string Mitigants { get; set; }
        public string LoggedBy { get; set; }

    }
}
