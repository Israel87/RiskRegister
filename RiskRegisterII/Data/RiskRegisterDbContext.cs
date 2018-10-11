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


        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<RiskMonitor> RiskMonitors { get; set; }
        public DbSet<RiskType> RiskTypes { get; set; }
        public DbSet<RegisterRisk> RiskRegisters { get; set; }
        public DbSet<ErrorRegisterModel> ErrorRegisters { get; set; }
        public DbSet<ComplaintRegister> ComplaintRegisters { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }



        // adding a modelbuilder method.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Models.User>().HasIndex(a => a.Username).IsUnique(true);
            modelBuilder.Entity<Models.Role>().Ignore(p => p.Users);
            modelBuilder.Entity<Models.User>().Ignore(p => p.Roles);
        }

    }
}
