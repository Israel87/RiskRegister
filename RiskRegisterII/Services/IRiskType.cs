using RiskRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Services
{
    public interface IRiskType
    {
        int AddRiskType(RiskType riskType);
        RiskType GetRiskType(int Id);
        //ICollection<RiskType> AllRiskTypes(string filter, string orderBy, int offset = 0, int page = 0);
        ICollection<RiskType> AllRiskTypes();
        int UpdateRiskType(int id, RiskType riskType);
        void DeleteRiskType(int Id);

    }
}
