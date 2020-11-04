using WebAPI.Data;
using System.Threading.Tasks;
using WebAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI.Repositories.Interface;
using WebAPI.Services.Interface;

namespace WebAPI.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository evento)
        {
            _eventoRepository = evento;
        }

        public async Task<List<Evento>> FindAll()
        {
            return await _eventoRepository.FindAllAsync();
        }
    }
}