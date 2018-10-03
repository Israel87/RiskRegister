using RiskRegisterII.Data;
using RiskRegisterII.Models;
using RiskRegisterII.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.ServiceHelper
{
    public class ComplaintRegisterService : IComplaintRegister
    {
        private readonly RiskRegisterDbContext _riskRegisterDbContext;

        public ComplaintRegisterService(RiskRegisterDbContext riskRegisterDbContext)
        {
            _riskRegisterDbContext = riskRegisterDbContext;
        }

        public int AddComplaint(ComplaintRegister complaintRegister)
        {

            try
            {
                if (complaintRegister != null)
                {
                    complaintRegister.DateReceived = DateTime.Now;
                    complaintRegister.Status = RiskRegister.CustomEnum.Enum.ProcessStatus.Pending;
                
                    _riskRegisterDbContext.complaintRegisters.Add(complaintRegister);
                    _riskRegisterDbContext.SaveChanges();
                    return complaintRegister.Id;
                }
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public ICollection<ComplaintRegister> AllComplaints()
        {
            return _riskRegisterDbContext.complaintRegisters.ToList();
        }

        public ComplaintRegister GetComplaint(int Id)
        {
            var _getComplaintById = _riskRegisterDbContext.complaintRegisters.FirstOrDefault(t => t.Id == Id);
            return _getComplaintById;
        }


        public void DeleteComplaints(int Id)
        {
            var _getComplaintById = GetComplaint(Id);
            if(_getComplaintById != null)
            {
                _riskRegisterDbContext.complaintRegisters.Remove(_getComplaintById);
                _riskRegisterDbContext.SaveChanges();
            }
        } 

        public int UpdateComplaintRegister(int id, ComplaintRegister complaintRegister)
        {
            var _getComplaintById = GetComplaint(id);
            if (_getComplaintById != null)
            {
                var existingDetails = _getComplaintById;
                existingDetails.NameofClient = complaintRegister.NameofClient;
                existingDetails.Description = complaintRegister.Description;
                existingDetails.ContactPerson = complaintRegister.ContactPerson;
                existingDetails.PhoneNumber = complaintRegister.PhoneNumber;
                existingDetails.EmailAddress = complaintRegister.EmailAddress;

                _riskRegisterDbContext.complaintRegisters.Update(existingDetails);
                _riskRegisterDbContext.SaveChanges();
                return existingDetails.Id;
            }
            return 0;

        }

        public void Dispose()
        {
            _riskRegisterDbContext.Dispose();
        }
    }
}
