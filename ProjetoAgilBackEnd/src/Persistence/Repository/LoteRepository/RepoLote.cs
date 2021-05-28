using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repository.Generic;
using Persistence.Repository.LoteRepository.Interface;

namespace Persistence.Repository.LoteRepository
{
    public class RepoLote : RepoGen<Lote, PersistenceContext>, IRepoLote
    {
        public RepoLote(PersistenceContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Lote>> GetLotesByEventoIdAsync(int eventoId)
        {
            IQueryable<Lote> query = DbSet;

            query = query.AsNoTracking()
                .Where(lote => lote.EventoId == eventoId);

            return await query.ToArrayAsync();
        }

        public async Task<Lote> GetLoteByIdsAsync(int eventoId, int id)
        {
            IQueryable<Lote> query = DbSet;

            query = query.AsNoTracking()
                .Where(lote => lote.EventoId == eventoId
                               && lote.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}