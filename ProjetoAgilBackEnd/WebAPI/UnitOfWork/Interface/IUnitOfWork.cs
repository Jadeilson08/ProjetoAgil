using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
