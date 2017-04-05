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
        private ISnowboardContext context { get; set; }
        public Root(
             ISnowboardContext _context
            ,IRepository<Role> _Roles
            ,IRepository<Entities.Snowboard> _Snowboards
            ,IRepository<User> _Users
            )
        {
            context = _context;
            Roles = _Roles;
            Snowboards = _Snowboards;
            Users = _Users;
        }
        public IRepository<Role> Roles { get; set; }

        public IRepository<Entities.Snowboard> Snowboards { get; set; }

        public IRepository<User> Users { get; set; }
    }
}
