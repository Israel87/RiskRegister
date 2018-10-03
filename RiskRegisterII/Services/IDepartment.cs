using RiskRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Services
{
    public interface IDepartment :IDisposable
    {
        int AddDepartment(Department department);
        Department GetDepartment(int Id);
        //ICollection<Department> AllDepartments(string filter, string orderBy, int offset = 0, int page = 0);
        ICollection<Department> AllDepartments();
        int UpdateDepartment(int id, Department department);
        void DeleteDepartment(int Id);

    }
}
