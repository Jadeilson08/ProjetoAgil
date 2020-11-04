using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.UnitOfWork.Interface;

namespace WebAPI.UnitOfWork
{
    public class UnitofWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitofWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChangesAsync();
        }
    }
}
