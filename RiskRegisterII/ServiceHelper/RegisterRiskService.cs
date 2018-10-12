using RiskRegister.Models;
using RiskRegisterII.Data;
using RiskRegisterII.Models;
using RiskRegisterII.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.ServiceHelper
{
    public class RegisterRiskService : IRegisterRisk, IRiskType
    {
        private readonly RiskRegisterDbContext _riskRegisterDbContext;

        public RegisterRiskService(RiskRegisterDbContext riskRegisterDbContext)
        {
            _riskRegisterDbContext = riskRegisterDbContext;
        }

        public int AddRiskRegister(RegisterRisk riskRegister)
        {
            var _getRisk = GetRiskType(riskRegister.RiskTypeId);
            try
            {
                if (riskRegister != null)
                {
                    riskRegister.DateCreated = DateTime.Now;
                  //  riskRegister.RiskTypeName = riskRegister.RiskType.Name;
                    riskRegister.Status = RiskRegister.CustomEnum.Enum.ProcessStatus.Pending;
                    riskRegister.RiskName = _getRisk.Name;

                    _riskRegisterDbContext.RiskRegisters.Add(riskRegister);
                    _riskRegisterDbContext.SaveChanges();
                    return riskRegister.Id;
                }
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public ICollection<RegisterRisk> AllRiskRegisters()
        {
            return _riskRegisterDbContext.RiskRegisters.ToList();
        }


        public RegisterRisk GetRiskRegister(int Id)
        {
            var _getRiskRegisterById = _riskRegisterDbContext.RiskRegisters.FirstOrDefault(t =>t.Id == Id);
            return _getRiskRegisterById;
        }

        public int UpdateRiskRegister(int id, RegisterRisk riskRegister)
        {
            var _getRiskRegisterById = GetRiskRegister(id);
            if (_getRiskRegisterById != null)
            {
                var existingDetails = _getRiskRegisterById;
                existingDetails.InherentRisk = riskRegister.InherentRisk;
                existingDetails.Mitigants = riskRegister.Mitigants;
                existingDetails.Id = riskRegister.Id;
                existingDetails.LoggedBy = riskRegister.LoggedBy;
                existingDetails.Activity = riskRegister.Activity;
                existingDetails.RiskTypeId = riskRegister.RiskTypeId;

                _riskRegisterDbContext.RiskRegisters.Update(existingDetails);
                _riskRegisterDbContext.SaveChanges();
                return existingDetails.Id;
            }
            return 0;

        }

        public void DeleteRiskRegister(int Id)
        {
            var _getRiskRegisterById = GetRiskRegister(Id);
            if (_getRiskRegisterById != null)
            {
                _riskRegisterDbContext.RiskRegisters.Remove(_getRiskRegisterById);
                _riskRegisterDbContext.SaveChanges();
            }

        }

        public void Dispose()
        {
            _riskRegisterDbContext.Dispose();
        }

        public int AddRiskType(RiskType riskType)
        {
            throw new NotImplementedException();
        }

        public RiskType GetRiskType(int Id)
        {
            return _riskRegisterDbContext.RiskTypes.FirstOrDefault(risk => risk.Id == Id);
        }

        public ICollection<RiskType> AllRiskTypes()
        {
            throw new NotImplementedException();
        }

        public int UpdateRiskType(int id, RiskType riskType)
        {
            throw new NotImplementedException();
        }

        public void DeleteRiskType(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
