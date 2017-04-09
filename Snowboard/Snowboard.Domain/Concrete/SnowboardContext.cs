using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowboard.Domain.Entities;
using Snowboard.Domain.Abstract;

namespace Snowboard.Domain.Concrete
{
    public class SnowboardContext : DbContext, ISnowboardContext
    {
        public DbSet<Entities.Snowboard> Snowboard { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        public DbSet<UserInRole> UserInRole { get; set; }
    }
}
