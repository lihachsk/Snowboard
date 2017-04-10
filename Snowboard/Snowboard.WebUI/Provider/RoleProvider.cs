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
            root.Role.AddUsersToRoles(usernames, roleNames);
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
            return root.Role.FindUsersInRole(roleName, usernameToMatch);
        }

        public override string[] GetAllRoles()
        {
            return root.Role.Get().Select(x => x.Name).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            return root.User.GetRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return root.Role.GetUsersInRole(roleName);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return root.User.IsUserInRole(username, roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            root.User.RemoveUsersFromRoles(usernames, roleNames);
        }

        public override bool RoleExists(string roleName)
        {
            return root.Role.RoleExists(roleName);
        }
    }
}