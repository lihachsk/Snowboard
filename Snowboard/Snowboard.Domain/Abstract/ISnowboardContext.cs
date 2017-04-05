using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowboard.Domain.Abstract
{
    public interface ISnowboardContext
    {
        DbSet<Entities.Snowboard> Snowboards { get; set; }
        DbSet<Entities.User> Users { get; set; }
        DbSet<Entities.Role> Roles { get; set; }
    }
}
