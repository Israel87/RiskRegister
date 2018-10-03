using RiskRegisterII.Data;
using RiskRegisterII.Models;
using RiskRegisterII.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.ServiceHelper
{
    public class ErrorRegisterService : IErrorRegister
    {
        private readonly RiskRegisterDbContext _riskRegisterDbContext;

        public ErrorRegisterService(RiskRegisterDbContext riskRegisterDbContext)
        {
            _riskRegisterDbContext = riskRegisterDbContext;
        }

        public int AddErrorRegister(ErrorRegisterModel errorRegister)
        {

            try
            {
                if (errorRegister != null)
                {
                        errorRegister.DateCreated = DateTime.Now;
                        errorRegister.Status = RiskRegister.CustomEnum.Enum.ProcessStatus.Pending;
                        errorRegister.ErrorStatus = RiskRegister.CustomEnum.Enum.ErrorRegisterStatus.Unresolved;
                        _riskRegisterDbContext.errorRegisters.Add(errorRegister);
                        _riskRegisterDbContext.SaveChanges();
                        return errorRegister.Id;
                }
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        //public ICollection<ErrorRegisterModel> AllErrorRegisters(string filter, string orderBy, int offset = 0, int page = 0)
        //{
        //    throw new NotImplementedException();
        //}
        public ICollection<ErrorRegisterModel> AllErrorRegisters()
        {
            return _riskRegisterDbContext.errorRegisters.ToList();
        }

         public ErrorRegisterModel GetErrorRegister(int Id)
        {
            var _getErrorRegisterById = _riskRegisterDbContext.errorRegisters.Where(t => t.Id == Id).FirstOrDefault();
            return _getErrorRegisterById; 
        }

        public void DeleteErrorRegister(int Id)
        {
            var _getErrorRegister = GetErrorRegister(Id);
            _riskRegisterDbContext.Remove(_getErrorRegister);
            _riskRegisterDbContext.SaveChanges();
        }

        public int UpdateErrorRegister(int id, ErrorRegisterModel errorRegister)
        {
            var _getErrorRegister = GetErrorRegister(id);
            if (_getErrorRegister != null)
            {
                var existingRegisters = _getErrorRegister;
                existingRegisters.DateUpdated = DateTime.Now;
                existingRegisters.Id = errorRegister.Id;
                existingRegisters.ErrorType = errorRegister.ErrorType;
                existingRegisters.DepartmentId = errorRegister.DepartmentId;
                existingRegisters.CompanyId = errorRegister.CompanyId;
                existingRegisters.RiskTypeId = errorRegister.RiskTypeId;
                existingRegisters.Narration = errorRegister.Narration;
                existingRegisters.Remark = errorRegister.Remark;
               

                _riskRegisterDbContext.errorRegisters.Update(existingRegisters);
                _riskRegisterDbContext.SaveChanges();
                 return existingRegisters.Id;
                
            }
            return 0;
        }
    }
}
