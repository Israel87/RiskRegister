using RiskRegister.Models;
using RiskRegisterII.Data;
using RiskRegisterII.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.ServiceHelper
{
    public class RiskTypeService : IRiskType
    {

        private readonly RiskRegisterDbContext _riskRegisterDbContext;

        public RiskTypeService(RiskRegisterDbContext riskRegisterDbContext)
        {
            _riskRegisterDbContext = riskRegisterDbContext;
        }

        public ICollection<RiskType> AllRiskTypes()
        {
            return _riskRegisterDbContext.riskTypes.ToList();
        }

        public RiskType GetRiskType(int Id)
        {
            return _riskRegisterDbContext.riskTypes.FirstOrDefault(risk =>risk.Id == Id);
        }
        public void DeleteRiskType(int Id)
        {
            var _getRiskType = GetRiskType(Id);
            _riskRegisterDbContext.Remove(_getRiskType);
            _riskRegisterDbContext.SaveChanges();

        }

        public int AddRiskType(RiskType riskType)
        {
            try
            {
                if (riskType != null)
                {
                    _riskRegisterDbContext.riskTypes.Add(riskType);
                    _riskRegisterDbContext.SaveChanges();
                    return riskType.Id;
                }
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public int UpdateRiskType(int id, RiskType riskType)
        {
            var _getRiskType = GetRiskType(id);
            if(_getRiskType != null)
            {
                var _existingRiskType = _getRiskType;
                _existingRiskType.Name = riskType.Name;

                _riskRegisterDbContext.riskTypes.Update(_existingRiskType);
                _riskRegisterDbContext.SaveChanges();

                return _existingRiskType.Id;
            }
            return 0;

        }
    }
}
