using Persistence.Context.Generic;
using Persistence.UnitOfWork.Generic.Interface;

namespace Persistence.UnitOfWork.Generic
{
    public abstract class UnitOfWorkGen<C> : IUnitOfWorkGen<C> 
        where C: ContextGen
    {
        private readonly C _context;

        public UnitOfWorkGen(C context)
        {
            _context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            throw new System.NotImplementedException();
        }
    }
}