using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repository.Generic;
using Persistence.Repository.PalestranteRepository.Interface;

namespace Persistence.Repository.PalestranteRepository
{
    public class RepoPalestrante : RepoGen<Palestrante, PersistenceContext>, IRepoPalestrante
    {
        public RepoPalestrante(PersistenceContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Palestrante>> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = DbSet
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<Palestrante>> GetAllPalestrantesAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = DbSet
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = DbSet
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}