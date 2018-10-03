using Microsoft.EntityFrameworkCore;
using RiskRegister.Models;
using RiskRegisterII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Data
{
    public class RiskRegisterDbContext: DbContext
    {

        public RiskRegisterDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Company> companies { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<RiskMonitor> riskMonitors { get; set; }
        public DbSet<RiskType> riskTypes { get; set; }
        public DbSet<ErrorRegisterModel> errorRegisters { get; set; }
        public DbSet<ComplaintRegister> complaintRegisters { get; set; }
    }
}
