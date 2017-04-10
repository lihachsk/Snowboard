using Snowboard.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowboard.Domain.Concrete
{
    public class EFRepository<T> : EFRepositoryBase<T>, IRepository<T> where T : class
    {
        public EFRepository(ISnowboardContext _context) : base(_context)
        {

        }
    }
}
