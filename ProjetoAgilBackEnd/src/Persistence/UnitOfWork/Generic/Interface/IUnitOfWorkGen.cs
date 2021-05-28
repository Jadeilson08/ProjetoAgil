using Persistence.Context.Generic;

namespace Persistence.UnitOfWork.Generic.Interface
{
    public interface IUnitOfWorkGen <C> where C : ContextGen
    {
        void SaveChanges();
        void RollBack();
    }
}