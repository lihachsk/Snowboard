using Snowboard.Domain.Abstract;
using Snowboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowboard.Domain.Concrete
{
    public class EFUser : EFRepositoryBase<User>, IUser
    {
        ISnowboardContext context;
        public EFUser(ISnowboardContext _context) : base(_context)
        {
            context = _context;
        }

        public string[] GetRolesForUser(string username)
        {
            return context
                .User
                .Where(x => x.Name == username)
                .First()?
                .Roles
                .Select(x => x.Name)
                .ToArray();
        }

        public bool IsUserInRole(string username, string roleName)
        {
            return context
                .User
                .Where(x => x.Name == username)
                .FirstOrDefault()
                .Roles
                .Any(x => x.Name == roleName);
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            var users = context
                .User
                .Where(x => usernames.Contains(x.Name) && x.Roles.Any(y => roleNames.Contains(y.Name)))
                .ToList();
            var roles = context
                .Role
                .Where(x => roleNames.Contains(x.Name))
                .ToList();
            foreach(var user in users)
            {
                var newRoles = user
                    .Roles
                    .Except(roles);
                user.Roles.Clear();
                foreach(var role in newRoles)
                {
                    user.Roles.Add(role);
                }
                context.SaveChanges();
            }
        }
    }
}
