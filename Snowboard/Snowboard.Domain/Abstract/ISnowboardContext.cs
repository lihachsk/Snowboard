using Snowboard.Domain.Entities;
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
        DbSet<Entities.Snowboard> Snowboard { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<UserInRole> UserInRole { get; set; }
        int SaveChanges();
    }
}
