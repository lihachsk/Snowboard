using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowboard.Domain.Entities;

namespace Snowboard.Domain.Abstract
{
    public interface IRoot
    {
        IRepository<Entities.Snowboard> Snowboard { get; set; }
        IRepository<User> User { get; set; }
        IRepository<Role> Role { get; set; }
    }
}
