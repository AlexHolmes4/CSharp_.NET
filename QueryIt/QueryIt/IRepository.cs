using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    public interface IRepository<T> : IReadOnlyRepository<T>, IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        int Commit();
    }
}
