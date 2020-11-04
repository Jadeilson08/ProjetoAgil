using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositories.Interface;

namespace WebAPI.Repositories
{
    public class EnventoRepository : IEventoRepository
    {
        private readonly AppDbContext _context;

        public EnventoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Evento>> FindAllAsync()
        {
            return await _context.Eventos.ToListAsync();
        }
    }
}
