using Persistence.Context;
using Persistence.Repository.EventoRepository;
using Persistence.Repository.EventoRepository.Interface;
using Persistence.Repository.LoteRepository;
using Persistence.Repository.LoteRepository.Interface;
using Persistence.Repository.PalestranteRepository;
using Persistence.Repository.PalestranteRepository.Interface;
using Persistence.UnitOfWork.Generic;
using Persistence.UnitOfWork.Interface;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : UnitOfWorkGen<PersistenceContext>, IUnitOfWork
    {
        private readonly PersistenceContext _context;
        public UnitOfWork(PersistenceContext context) : base(context)
        {
            _context = context;
        }

        private IRepoEvento _repoEvento;
        private IRepoPalestrante _repoPalestrante;
        private IRepoLote _repoLote;

        public IRepoLote RepoLote
        {
            get
            {
                return _repoLote ??= new RepoLote(_context);
            }
        }
        public IRepoPalestrante RepoPalestrante
        {
            get
            {
                return _repoPalestrante ??= new RepoPalestrante(_context);
            }
        }
        public IRepoEvento RepoEvento
        {
            get
            {
                return _repoEvento ??= new RepoEvento(_context);
            }
        }
    }
}