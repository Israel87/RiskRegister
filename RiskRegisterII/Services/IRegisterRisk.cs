using RiskRegisterII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Services
{
    public interface IRegisterRisk : IDisposable
    {
        int AddRiskRegister(RegisterRisk riskRegister);
        RegisterRisk GetRiskRegister(int Id);
        //ICollection<RiskType> AllRiskTypes(string filter, string orderBy, int offset = 0, int page = 0);
        ICollection<RegisterRisk> AllRiskRegisters();
        int UpdateRiskRegister(int id, RegisterRisk riskRegister);
        void DeleteRiskRegister(int Id);
    }
}
