using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interface
{
    public interface IEventoRepository
    {
        Task<List<Evento>> FindAllAsync();
        Task SaveAsync(Evento evento);
        Task<Evento> FindByIdAsync(int id);

    }
}
