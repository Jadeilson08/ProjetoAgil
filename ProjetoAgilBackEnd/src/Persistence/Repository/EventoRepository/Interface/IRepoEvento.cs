using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Persistence.Context;
using Persistence.Repository.Generic.Interface;

namespace Persistence.Repository.EventoRepository.Interface
{
    public interface IRepoEvento : IRepoGen<Evento, PersistenceContext>
    {
        Task<IEnumerable<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<IEnumerable<Evento>> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}