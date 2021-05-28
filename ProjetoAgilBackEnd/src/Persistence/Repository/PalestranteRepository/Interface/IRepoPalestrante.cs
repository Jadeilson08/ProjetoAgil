using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Persistence.Context;
using Persistence.Repository.Generic.Interface;

namespace Persistence.Repository.PalestranteRepository.Interface
{
    public interface IRepoPalestrante : IRepoGen<Palestrante, PersistenceContext>
    {
        Task<IEnumerable<Palestrante>> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<IEnumerable<Palestrante>> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}