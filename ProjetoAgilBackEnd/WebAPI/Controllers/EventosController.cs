using System.Threading.Tasks; // Trabalhando de forma assíncrona
using Microsoft.AspNetCore.Mvc; // herança ControllerBase
using WebAPI.Services;
using Microsoft.AspNetCore.Http;
using WebAPI.Services.Interface;
using WebAPI.Facades.Interface;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventosFacade _eventosFacade;
        public EventosController(IEventosFacade eventosFacade)
        {
            _eventosFacade = eventosFacade;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventosFacade.FindAll();
                return Ok(eventos);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "No value");
            }
        }
    }
}