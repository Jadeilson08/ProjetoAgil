using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Persistence.Context;
using Persistence.Repository.Generic.Interface;

namespace Persistence.Repository.LoteRepository.Interface
{
    public interface IRepoLote : IRepoGen<Lote, PersistenceContext>
    {
        Task<IEnumerable<Lote>> GetLotesByEventoIdAsync(int eventoId);
        Task<Lote> GetLoteByIdsAsync(int eventoId, int id);
    }
}