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
    }
}
