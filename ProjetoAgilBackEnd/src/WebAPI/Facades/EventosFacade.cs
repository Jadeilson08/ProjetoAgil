using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Facades.Interface;
using WebAPI.Models;
using WebAPI.Repositories.Interface;

namespace WebAPI.Facades
{
    public class EventosFacade: IEventosFacade
    {
        private readonly IEventoRepository _eventoRepository;
        public EventosFacade(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<List<Evento>> FindAll() 
        {
            return await _eventoRepository.FindAllAsync();
        }

        public async Task<Evento> FindById(int id)
        {
            return await _eventoRepository.FindByIdAsync(id);
        }

        public async Task SaveAsync(Evento evento)
        {
            await _eventoRepository.SaveAsync(evento);
        }
    }
}
