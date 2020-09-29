using WebAPI.Data;
using System.Threading.Tasks;
using WebAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace WebAPI.Services
{
    public class EventoService
    {
        private readonly AppDbContext _context;

        public EventoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Evento>> FindAll()
        {
            return await _context.Eventos.ToListAsync();
        }
    }
}