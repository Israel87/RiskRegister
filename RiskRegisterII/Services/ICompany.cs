using RiskRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Services
{
    public interface ICompany : IDisposable
    {
        int AddCompany(Company company);
        Company GetCompany(int Id);
        //ICollection<Company> AllCompanies(string filter, string orderBy, int offset = 0, int page = 0);
        ICollection<Company> AllCompanies();
        int UpdateCompany(int id, Company company);
        void DeleteCompany(int Id);

    }
}
