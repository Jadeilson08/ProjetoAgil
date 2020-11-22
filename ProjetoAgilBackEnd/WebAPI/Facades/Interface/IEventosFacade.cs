using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Facades.Interface
{
    public interface IEventosFacade
    {
        Task<List<Evento>> FindAll();
        Task SaveAsync(Evento evento);
        Task<Evento> FindById(int id);
    }
}
