using RiskRegisterII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Services
{
    public interface IErrorRegister
    {
        int AddErrorRegister(ErrorRegisterModel errorRegister);
        ErrorRegisterModel GetErrorRegister(int Id);
        //ICollection<ErrorRegisterModel> AllErrorRegisters(string filter, string orderBy, int offset = 0, int page = 0);
        ICollection<ErrorRegisterModel> AllErrorRegisters();
        int UpdateErrorRegister(int id, ErrorRegisterModel errorRegister);
        void DeleteErrorRegister(int Id);
    }
}
