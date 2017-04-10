using Snowboard.Domain.Abstract;
using Snowboard.Domain.Entities;
using Snowboard.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Snowboard.WebUI.Provider
{
    public class SNRoleProvider : RoleProvider
    {
        private IRoot root { get; set; }
        private User User { get; set; }

        public SNRoleProvider(IRoot _root)
        {
            root = _root;
            User = (User)HttpContext.Current.Session["User"];
            ApplicationName = ConfigurationManager.AppSettings["ApplicationName"].ToString();
        }
        public override string ApplicationName { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            IEnumerable<Guid> UserId = root.User.Get(x => usernames.Contains(x.Name)).Select(x => x.Id);
            IEnumerable<Guid> RoleId = root.Role.Get(x => roleNames.Contains(x.Name)).Select(x => x.Id);
            var result = AddUserToRoleById(UserId, RoleId);
        }
        public IEnumerable<Result> AddUserToRoleById(IEnumerable<Guid> UserId, IEnumerable<Guid> RoleId)
        {
            var Result = new List<Result>();
            foreach (var user in UserId)
            {
                foreach (var role in RoleId)
                {
                    try
                    {
                        root.UserInRole.Add(new UserInRole()
                        {
                            CreatedOn = DateTime.UtcNow
                            ,
                            CreatedBy = User.Id
                            ,
                            ModifiedOn = DateTime.UtcNow
                            ,
                            ModifiedBy = User.Id
                            ,
                            UserId = user
                            ,
                            RoleId = role
                        });
                        Result.Add(new Result() { Success = true });
                    }
                    catch(Exception e)
                    {
                        Result.Add(new Result() {
                            Success = false
                            ,ErrorNumber = e.HResult
                            ,MessageError = e.Message
                        });
                    }
                }
            }
            return Result;
        }

        public override void CreateRole(string roleName)
        {
            if(!root.Role.Any(x => x.Name == roleName))
            {
                root.Role.Add(new Role()
                {
                    CreatedOn = DateTime.UtcNow
                    ,
                    CreatedBy = User.Id
                    ,
                    ModifiedOn = DateTime.UtcNow
                    ,
                    ModifiedBy = User.Id
                    ,
                    Name = roleName
                });
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            Role role = root.Role.Get(x => x.Name == roleName).FirstOrDefault();
            if (role != null && role.Id != Guid.Empty)
            {
                root.Role.Remove(role);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<User> FindUsersInRole(Guid RoleId, string usernameToMatch)
        {
            var user = root.UserInRole.Join(root.User, x => x.UserId, y => y.Id, (x, y) => new { UserInRole = x, User = y })
                .Join(root.Role, z => z.UserInRole.RoleId, y => y.Id, (z, y) => new { UserInRole = z.UserInRole, User = z.User, Role = y })
                .Where(x => x.Role.Id == RoleId && x.User.Name.Contains(usernameToMatch))
                .Select(x => x.User)
                .ToList();
            return user;
        }

        public override string[] GetAllRoles()
        {
            return root.Role.Get().Select(x => x.Name).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}