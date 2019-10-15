using Microsoft.EntityFrameworkCore;
using Myx.Core.Entities;
using Myx.Message.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myx.Message.EntityFrameworkCore.Repository
{
    public class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : MyxBaseEntity<TKey>
    {
        protected readonly MyxMessageDbContext dbContext;

        protected readonly DbSet<T> Set;

        public BaseRepository(MyxMessageDbContext dbContext)
        {
            this.dbContext = dbContext;
            Set = dbContext.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            var e = await Set.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return e.Entity;
        }

        public IQueryable<T> Querable()
        {
            return Set.AsQueryable();
        }
    }
}
