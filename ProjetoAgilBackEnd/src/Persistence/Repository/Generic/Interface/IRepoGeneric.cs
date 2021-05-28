using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interface;
using Persistence.Context.Generic;

namespace Persistence.Repository.Generic.Interface
{
    public interface IRepoGen<T, C> 
        where T : class, IEntity
        where C : ContextGen
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T GetById(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void DeleteRange(IEnumerable<T> entity);
    }
}