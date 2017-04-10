using Snowboard.Domain.Abstract;
using Snowboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowboard.Domain.Concrete
{
    public class EFRole : EFRepositoryBase<Role>, IRole
    {
        ISnowboardContext context;
        public EFRole(ISnowboardContext _context) : base(_context)
        {
            context = _context;
        }

        public void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            var users = context.User.Where(x => usernames.Contains(x.Name));
            var roles = context.Role.Where(x => roleNames.Contains(x.Name));
            foreach (var user in users)
            {
                foreach (var role in roles)
                {
                    user.Roles.Add(role);
                }
            }
            context.SaveChanges();
        }

        public string[] FindUsersInRole(string RoleName, string usernameToMatch)
        {
            return context
                .Role
                .Where(x => x.Name == RoleName)
                .First()?
                .Users
                .Where(x => usernameToMatch.Contains(x.Name))
                .Select(x => x.Name)
                .ToArray();
        }

        public string[] GetUsersInRole(string roleName)
        {
            return context
                .Role
                .Where(x => x.Name == roleName)
                .First()?
                .Users
                .Select(x => x.Name)
                .ToArray();
        }

        public bool RoleExists(string roleName)
        {
            return context.Role
                .Any(x => x.Name == roleName);
        }
    }
}
