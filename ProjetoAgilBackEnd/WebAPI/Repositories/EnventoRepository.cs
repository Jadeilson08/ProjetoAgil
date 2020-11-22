using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositories.Interface;
using WebAPI.UnitOfWork.Interface;

namespace WebAPI.Repositories
{
    public class EnventoRepository : IEventoRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public EnventoRepository(AppDbContext context,
                                 IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Evento>> FindAllAsync()
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task SaveAsync(Evento evento)
        {
            await _context.AddAsync(evento);
            await _unitOfWork.Commit();

        }
    }
}
