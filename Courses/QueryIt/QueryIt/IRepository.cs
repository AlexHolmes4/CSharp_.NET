using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>
    {

    }
}
