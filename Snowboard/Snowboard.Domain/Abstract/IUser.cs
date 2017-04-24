using Snowboard.Domain.Entities;

namespace Snowboard.Domain.Abstract
{
    public interface IUser : IRepository<User>
    {
        string[] GetRolesForUser(string username);
        bool IsUserInRole(string username, string roleName);
        void RemoveUsersFromRoles(string[] usernames, string[] roleNames);
        bool CheckPassword(string login, string password);
    }
}