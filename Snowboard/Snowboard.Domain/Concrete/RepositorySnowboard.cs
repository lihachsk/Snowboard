using Snowboard.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowboard.Domain.Entities;

namespace Snowboard.Domain.Concrete
{
    public class RepositorySnowboard : IRepository<Snowboard.Domain.Entities.Snowboard>
    {
        public void Create(Entities.Snowboard item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Entities.Snowboard Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Snowboard> GetList()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Entities.Snowboard item)
        {
            throw new NotImplementedException();
        }
    }
}
