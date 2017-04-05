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
        IRepository<Entities.Snowboard> Snowboards { get; set; }
        IRepository<User> Users { get; set; }
        IRepository<Role> Roles { get; set; }
    }
}
