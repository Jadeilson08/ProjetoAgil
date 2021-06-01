using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.EventoService.Interface;
using Application.Services.Generic;
using Domain;
using Persistence.UnitOfWork.Interface;

namespace Application.Services.EventoService
{
    public class SrEvento : SrGen, ISrEvento
    {
        private readonly IUnitOfWork _unitOfWork;
        public SrEvento(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Evento NewEvento(Evento evento)
        {
            try
            {
                _unitOfWork.RepoEvento.Add(evento);
                _unitOfWork.SaveChanges();
                return evento;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public Evento UpdateEvento(Evento evento)
        {
            _unitOfWork.RepoEvento.Update(evento);
            _unitOfWork.SaveChanges();
            return evento;
        }

        public void DeleteEvento(Evento evento)
        {
            _unitOfWork.RepoEvento.Delete(evento);
            _unitOfWork.SaveChanges();
        }
        public async Task<IEnumerable<Evento>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            return await _unitOfWork.RepoEvento.GetAllEventosByTemaAsync(tema, includePalestrantes);
        }

        public async Task<IEnumerable<Evento>> GetAllEventosAsync(bool includePalestrantes = false)
        {
            return await _unitOfWork.RepoEvento.GetAllEventosAsync(includePalestrantes);
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            return await _unitOfWork.RepoEvento.GetEventoByIdAsync(eventoId, includePalestrantes);
        }
    }
}