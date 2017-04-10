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
    public class EFSnowboardContext : DbContext, ISnowboardContext
    {
        public DbSet<Entities.Snowboard> Snowboard { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserInRole> UserInRole { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(p => p.Roles)
                .WithMany(c => c.Users)
                .Map(m =>
                {
                    m.ToTable("UserInRole");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
