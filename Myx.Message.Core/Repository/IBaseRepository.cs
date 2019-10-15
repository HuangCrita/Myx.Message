using Myx.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myx.Message.Core.Repository
{
    public interface IBaseRepository<T,TKey> where T : MyxBaseEntity<TKey>
    {
        Task<T> Create(T entity);

        IQueryable<T> Querable();
    }
}
