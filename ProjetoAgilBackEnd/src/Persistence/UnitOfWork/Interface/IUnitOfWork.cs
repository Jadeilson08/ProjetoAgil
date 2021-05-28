using Persistence.Context;
using Persistence.Repository.EventoRepository.Interface;
using Persistence.Repository.LoteRepository.Interface;
using Persistence.Repository.PalestranteRepository.Interface;
using Persistence.UnitOfWork.Generic.Interface;

namespace Persistence.UnitOfWork.Interface
{
    public interface IUnitOfWork : IUnitOfWorkGen<PersistenceContext>
    {
        IRepoEvento RepoEvento { get; }
        IRepoPalestrante RepoPalestrante { get; }
        IRepoLote RepoLote { get; }
    }
}