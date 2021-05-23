using System.Threading.Tasks; // Trabalhando de forma assíncrona
using Microsoft.AspNetCore.Mvc; // herança ControllerBase
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        //private readonly IEventosFacade _eventosFacade;
        /*public EventosController(IEventosFacade eventosFacade)
        {
            _eventosFacade = eventosFacade;
        }*/

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                //var eventos = await _eventosFacade.FindAll();
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "No value");
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                //var eventos = await _eventosFacade.FindById(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "No value");
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save([FromBody] Evento evento)
        {
            try
            {
                //await _eventosFacade.SaveAsync(evento);
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "No value");
            }
        }

        //upload de foto
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                //arquivo que vem da requisicao
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Fotos");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if(file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, fileName.Replace("\"", " ").Trim());

                    using(var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok();
                }

                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "No value");
            }
            return BadRequest();
        }
    }
}