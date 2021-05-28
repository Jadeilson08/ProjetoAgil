using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.EventoService.Interface;
using Application.Services.Generic;
using Domain;

namespace Application.Services.EventoService
{
    public class SrEvento : SrGen, ISrEvento
    {
        private readonly ISrEvento _srEvento;
        public SrEvento(ISrEvento srEvento)
        {
            _srEvento = srEvento;
        }
        public async Task<IEnumerable<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            return await _srEvento.GetAllEventosByTemaAsync(tema, includePalestrantes);
        }

        public async Task<IEnumerable<Evento>> GetAllEventosAsync(bool includePalestrantes = false)
        {
            return await _srEvento.GetAllEventosAsync(includePalestrantes);
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            return await _srEvento.GetEventoByIdAsync(eventoId, includePalestrantes);
        }
    }
}