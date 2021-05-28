using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Context.Generic;
using Persistence.Repository.Generic.Interface;

namespace Persistence.Repository.Generic
{
    public abstract class RepoGen<T, C> : IRepoGen<T, C> 
        where T : class, IEntity
        where C : ContextGen
    {
        
        protected readonly C Context;
        protected readonly DbSet<T> DbSet;

        protected RepoGen(C context)
        {
            this.Context = context;
            DbSet = this.Context.Set<T>();
        }
        public IEnumerable<T> Get() => DbSet.AsEnumerable<T>();

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate) => DbSet.Where(predicate).AsEnumerable<T>();

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).SingleOrDefault();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            DbSet.Update(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }
    }
}