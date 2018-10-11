using RiskRegisterII.Data;
using RiskRegisterII.Models;
using RiskRegisterII.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.ServiceHelper
{
    public class UserManager : IUserManager
    {
        private readonly RiskRegisterDbContext _riskRegisterDbContext;

        public UserManager(RiskRegisterDbContext riskRegisterDbContext)
        {
            _riskRegisterDbContext = riskRegisterDbContext;
        }

        public ICollection<User> AllUsers(string filter, string orderBy, int offset = 0, int page = 0)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> AllUsersInOrganisation(int OrganisationID)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> AllUsersInRole(int RoleID)
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(string email, string password)
        {
            return _riskRegisterDbContext.Users.Any(p => p.Username == email && p.Password == password);
        }

        public bool BlockUser(int userID, bool block)
        {
            var userToBlock = _riskRegisterDbContext.Users.SingleOrDefault(a => a.ID == userID);
            if (userToBlock != null)
            {
                userToBlock.IsBlocked = block;
                _riskRegisterDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetUser(int ID)
        {
            return _riskRegisterDbContext.Users.SingleOrDefault(a => a.ID == ID);
        }

        public User GetUser(string email)
        {
            return _riskRegisterDbContext.Users.SingleOrDefault(a => a.Username.ToLower() == email.ToLower());
        }

        public UserDetail GetUserDetail(int ID)
        {
            return _riskRegisterDbContext.UserDetails.SingleOrDefault(a => a.ID == ID);
        }

        public UserDetail GetUserDetail(string email)
        {
            return _riskRegisterDbContext.UserDetails.SingleOrDefault(a => a.User.Username.ToLower() == email.ToLower());
        }

        public UserDetail GetUserDetailByUserID(int userID)
        {
            return _riskRegisterDbContext.UserDetails.SingleOrDefault(a => a.User.ID == userID);
        }

        public ICollection<Role> GetUserRoles(int userID)
        {
            var roles = from ur in _riskRegisterDbContext.UserRoles
                        join r in _riskRegisterDbContext.Roles on ur.RoleID equals r.ID
                        where ur.UserID == userID
                        select r;

            return roles.ToList();
        }

        public int SaveUser(User User)
        {
            if(User != null)
            {
                _riskRegisterDbContext.Users.Add(User);
                _riskRegisterDbContext.SaveChanges();
                return User.ID;
            }
            return 0;
        }

        public int SaveUserDetail(UserDetail userDetail)
        {
            if (userDetail !=null)
            {
                _riskRegisterDbContext.UserDetails.Add(userDetail);
                _riskRegisterDbContext.SaveChanges();
                return userDetail.ID;
            }
            return 0;
        }
    }
}
