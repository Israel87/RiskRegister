using RiskRegister.Models;
using RiskRegisterII.Data;
using RiskRegisterII.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.ServiceHelper
{
    public class DepartmentService : IDepartment
    {
        private readonly RiskRegisterDbContext _riskRegisterDbContext;

        public DepartmentService(RiskRegisterDbContext riskRegisterDbContext)
        {
            _riskRegisterDbContext = riskRegisterDbContext;
        }

        public int AddDepartment(Department department)
        {
            try
            {
                if (department != null)
                {
                    _riskRegisterDbContext.Departments.Add(department);
                    _riskRegisterDbContext.SaveChanges();
                    return department.Id;
                }
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public ICollection<Department> AllDepartments()
        {
            return _riskRegisterDbContext.Departments.ToList();
        }

        public Department GetDepartment(int Id)
        {
            return _riskRegisterDbContext.Departments.FirstOrDefault(dept =>dept.Id == Id);
        }


        public void DeleteDepartment(int Id)
        {
            var _getDepartment = GetDepartment(Id);
            _riskRegisterDbContext.Departments.Remove(_getDepartment);
            _riskRegisterDbContext.SaveChanges();
        }

        public int UpdateDepartment(int id, Department department)
        {
            var _getDepartment = GetDepartment(id);
            if (_getDepartment != null)
            {
                var existingDetails = _getDepartment;
                existingDetails.Name = _getDepartment.Name;
                _riskRegisterDbContext.Departments.Update(existingDetails);
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
