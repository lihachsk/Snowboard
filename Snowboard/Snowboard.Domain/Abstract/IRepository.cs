﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowboard.Domain.Abstract
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetList();
        T Get(Guid Id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid Id);
        void Save();
    }
}
