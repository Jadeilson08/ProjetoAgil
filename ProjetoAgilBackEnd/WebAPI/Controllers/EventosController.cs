using System.Threading.Tasks; // Trabalhando de forma assíncrona
using Microsoft.AspNetCore.Mvc; // herança ControllerBase
using WebAPI.Services;
using Microsoft.AspNetCore.Http;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly EventoService _service;
        public EventosController(EventoService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _service.FindAll();
                return Ok(eventos);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "No value");
            }
        }
    }
}