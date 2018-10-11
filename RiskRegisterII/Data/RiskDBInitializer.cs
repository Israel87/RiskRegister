using RiskRegisterII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Data
{
    public class RiskDBInitializer
    {
        public static void SeedData(RiskRegisterDbContext riskRegisterDbContext)
        {
            riskRegisterDbContext.Database.EnsureCreated();

            #region add roles 
            if (riskRegisterDbContext.Find(typeof(Role), 1) != null)
            {
                return;
            }

            IList<Role> roles = new List<Role>
            {
                new Role{ Name="SuperAdmin", Description="Super Administrator", EnteredBy="System", EntryDate=DateTime.Now},
                new Role{ Name="Admin", Description="Administrator", EnteredBy="System", EntryDate=DateTime.Now},
                new Role{ Name="User", Description="User", EnteredBy="System", EntryDate=DateTime.Now},
            };
            riskRegisterDbContext.Roles.AddRange(roles);
            riskRegisterDbContext.SaveChanges();

            IList<User> users = new List<User>
            {
                new User{ Username = "test1@parthianpartnersng.com", IsBlocked = false, IsConfirm = true, Password = "test123", UserDetail = new UserDetail{Lastname = "Test", Email ="test1@parthianpartnersng.com",MiddleName ="Ninja",FirstName="SuperMan",Gender= CustomEnum.Gender.Male,Phone="08132457896"} },
                new User{Username = "test2@parthianpartnersng.com", IsBlocked = false, IsConfirm = true, Password = "test123", UserDetail = new UserDetail{Lastname = "Test", Email ="test2@parthianpartnersng.com",MiddleName ="Ninja",FirstName="SpiderMan",Gender=CustomEnum.Gender.Male,Phone="08132457896"} },
                new User{Username = "test3@parthianpartnersng.com", IsBlocked = false, IsConfirm = true, Password = "test123", UserDetail = new UserDetail{Lastname = "Test", Email ="test3@parthianpartnersng.com",MiddleName ="Ninja",FirstName="BatMan",Gender=CustomEnum.Gender.Male,Phone="08132457896"}},
              
            };
            riskRegisterDbContext.Users.AddRange(users);
            riskRegisterDbContext.SaveChanges();

            IList<UserRole> userRoles = new List<UserRole>
            {
                new UserRole{ UserID = 1, RoleID =1},
                new UserRole{ UserID = 2, RoleID =2},
                new UserRole{ UserID = 3, RoleID =3},
                new UserRole{ UserID = 4, RoleID =3}
            };
            riskRegisterDbContext.UserRoles.AddRange(userRoles);
            riskRegisterDbContext.SaveChanges();


            #endregion


        }
    }
}
