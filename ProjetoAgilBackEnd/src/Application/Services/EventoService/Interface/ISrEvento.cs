using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Generic.Interface;
using Domain;

namespace Application.Services.EventoService.Interface
{
    public interface ISrEvento : ISrGen
    {
        void NewEvento(Evento evento);
        void UpdateEvento(Evento evento);
        void DeleteEvento(Evento evento);
        Task<IEnumerable<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<IEnumerable<Evento>> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}