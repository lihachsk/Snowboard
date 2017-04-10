using Snowboard.Domain.Entities;
using System.Collections.Generic;

namespace Snowboard.Domain.Abstract
{
    public interface IRole : IRepository<Role>
    {
        string[] FindUsersInRole(string RoleName, string usernameToMatch);
        string[] GetUsersInRole(string roleName);
        bool RoleExists(string roleName);
        void AddUsersToRoles(string[] usernames, string[] roleNames);
    }
}