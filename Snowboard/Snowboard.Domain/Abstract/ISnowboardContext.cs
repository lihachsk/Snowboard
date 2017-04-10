using Snowboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowboard.Domain.Abstract
{
    public interface ISnowboardContext
    {
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        void Dispose(bool disposing);
        void Dispose();
    }
}
