using Snowboard.Domain.Abstract;
using Snowboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowboard.Domain.Concrete
{
    public class RepositoryRole : IRepository<Role>
    {
        private ISnowboardContext context { get; set; }
        public RepositoryRole(ISnowboardContext _context)
        {
            context = _context;
        }
        public void Create(Role item)
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

        public Role Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetList()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Role item)
        {
            throw new NotImplementedException();
        }
    }
}
