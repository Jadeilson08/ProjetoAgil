using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repository.EventoRepository.Interface;
using Persistence.Repository.Generic;

namespace Persistence.Repository.EventoRepository
{
    public class RepoEvento : RepoGen<Evento, PersistenceContext>, IRepoEvento
    {
        public RepoEvento(PersistenceContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = DbSet
                .Include(x => x.Lotes)
                .Include(x => x.RedeSociais);
            if (includePalestrantes)
            {
                query = query.Include(x => x.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(x => x.Tema.ToUpper().Contains(tema.ToUpper()));

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Domain.Evento>> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Domain.Evento> query = DbSet
                .Include(x => x.Lotes)
                .Include(x => x.RedeSociais);
            if (includePalestrantes)
            {
                query = query.Include(x => x.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToListAsync();
        }

        public async Task<Domain.Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Domain.Evento> query = DbSet
                .Include(x => x.Lotes)
                .Include(x => x.RedeSociais);
            if (includePalestrantes)
            {
                query = query.Include(x => x.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(x => x.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}