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
            )
        {
            Role = _Role;
            Snowboard = _Snowboard;
            User = _User;
        }

        public IRepository<Role> Role { get; set; }

        public IRepository<Entities.Snowboard> Snowboard { get; set; }

        public IRepository<User> User { get; set; }
    }
}
