using Microsoft.EntityFrameworkCore;
using RiskRegister.Models;
using RiskRegisterII.Data;
using RiskRegisterII.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.ServiceHelper
{
    public class CompanyService : ICompany
    {
        private readonly RiskRegisterDbContext _riskRegisterDbContext;

        public CompanyService(RiskRegisterDbContext riskRegisterDbContext)
        {
            _riskRegisterDbContext = riskRegisterDbContext;
        }

        public int AddCompany(Company company)
        {
            try
            {
                if (company != null)
                {
                    _riskRegisterDbContext.companies.Add(company);
                    _riskRegisterDbContext.SaveChanges();
                    return company.Id;
                }
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
        }


        public void DeleteCompany(int Id)
        {
            var _getCompany = _riskRegisterDbContext.companies.FirstOrDefault(t => t.Id == Id);
            _riskRegisterDbContext.Remove(_getCompany);
            _riskRegisterDbContext.SaveChanges();
           
        }

        public Company GetCompany(int Id)
        {
            return _riskRegisterDbContext.companies.Where(t=>t.Id ==Id).FirstOrDefault();
        }


        public ICollection<Company> AllCompanies()
        {
            return _riskRegisterDbContext.companies.ToList();
        }

        public int UpdateCompany(int id, Company company)
        {
            var _getCompanyDetails = GetCompany(id);
            if(_getCompanyDetails !=null)
            {
                var existingDetails = _getCompanyDetails;
                existingDetails.Name = _getCompanyDetails.Name;
                _riskRegisterDbContext.companies.Update(existingDetails);
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
