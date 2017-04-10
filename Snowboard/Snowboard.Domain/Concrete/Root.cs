using Snowboard.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowboard.Domain.Entities;

namespace Snowboard.Domain.Concrete
{
    public class Root : IRoot
    {
        public Root(
             IRepository<Role> _Role
            ,IRepository<Entities.Snowboard> _Snowboard
            ,IRepository<User> _User
            ,IUserInRole<UserInRole> _UserInRole
            )
        {
            Role = _Role;
            Snowboard = _Snowboard;
            User = _User;
            UserInRole = _UserInRole;
        }

        public IRepository<Role> Role { get; set; }

        public IRepository<Entities.Snowboard> Snowboard { get; set; }

        public IRepository<User> User { get; set; }

        public IUserInRole<UserInRole> UserInRole { get; set; }

        public IEnumerable<User> FindUsersInRole(Guid RoleId, string usernameToMatch)
        {
            return UserInRole.Join(User, x => x.UserId, y => y.Id, (x, y) => new { UserInRole = x, User = y })
                .Join(Role, z => z.UserInRole.RoleId, y => y.Id, (z, y) => new { UserInRole = z.UserInRole, User = z.User, Role = y })
                .Where(x => x.Role.Id == RoleId && x.User.Name.Contains(usernameToMatch))
                .Select(x => x.User)
                .ToList();
        }
    }
}
