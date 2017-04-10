using Snowboard.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowboard.Domain.Entities;
using System.Data.Entity;

namespace Snowboard.Domain.Concrete
{
    public class EFRoot : IRoot
    {
        ISnowboardContext context;
        public EFRoot(
             IRole _Role
            ,IRepository<Entities.Snowboard> _Snowboard
            ,IUser _User
            ,ISnowboardContext _context
            )
        {
            Role = _Role;
            Snowboard = _Snowboard;
            User = _User;
            context = _context;
        }

        public IRole Role { get; set; }

        public IRepository<Entities.Snowboard> Snowboard { get; set; }

        public IUser User { get; set; }
    }
}
