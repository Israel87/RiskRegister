using RiskRegisterII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Services
{
    public interface IUserManager
    {
        #region users
        int SaveUser(Models.User User);
        bool BlockUser(int userID, bool block);
        Models.User GetUser(int ID);
        Models.User GetUser(string username);
        ICollection<Models.User> AllUsers(string filter, string orderBy, int offset = 0, int page = 0);
        ICollection<Models.User> AllUsersInRole(int RoleID);
        ICollection<Models.User> AllUsersInOrganisation(int OrganisationID);
        bool Authenticate(string email, string password);
        #endregion

        #region UserDetail
        int SaveUserDetail(Models.UserDetail userDetail);
        Models.UserDetail GetUserDetail(int ID);
        Models.UserDetail GetUserDetailByUserID(int userID);
        Models.UserDetail GetUserDetail(string email);
        #endregion

        #region Roles
        ICollection<Role> GetUserRoles(int userID);
        #endregion
    }
}
