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
        public DbSet<Entities.Snowboard> Snowboards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
