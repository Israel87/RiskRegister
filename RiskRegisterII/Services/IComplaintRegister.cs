using RiskRegisterII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Services
{
    public interface IComplaintRegister : IDisposable
    {

        int AddComplaint(ComplaintRegister complaintRegister);
        ComplaintRegister GetComplaint(int Id);
        //ICollection<Company> AllCompanies(string filter, string orderBy, int offset = 0, int page = 0);
        ICollection<ComplaintRegister> AllComplaints();
        int UpdateComplaintRegister(int id, ComplaintRegister complaintRegister);
        void DeleteComplaints(int Id);

    }
}
