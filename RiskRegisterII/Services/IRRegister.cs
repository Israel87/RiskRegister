using RiskRegisterII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Services
{
    interface IRegisterRisk
    {
        int AddRegister(RegisterRisk riskRegister);
    }
}
