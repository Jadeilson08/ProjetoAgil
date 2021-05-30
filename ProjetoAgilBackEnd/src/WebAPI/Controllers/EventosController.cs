using System;
using System.Collections.Generic;
using System.Threading.Tasks; // Trabalhando de forma assíncrona
using Microsoft.AspNetCore.Mvc; // herança ControllerBase
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Application.Services.EventoService.Interface;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ISrEvento _srEvento;
        public EventosController(ISrEvento srEvento)
        {
            _srEvento = srEvento;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Evento> eventos = await _srEvento.GetAllEventosAsync();
                if (eventos == null || eventos.Count() == 0) return NoContent();
                return Ok(eventos);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No value");
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Evento evento = await _srEvento.GetEventoByIdAsync(id);
                if (evento == null ) return NotFound();
                return Ok(evento);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No value");
            }
        }
        [HttpGet("{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                IEnumerable<Evento> eventos = await _srEvento.GetAllEventosByTemaAsync(tema);
                if (eventos == null || eventos.Count() == 0) return NotFound();
                return Ok(eventos);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No value");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Evento evento)
        {
            try
            {
                _srEvento.NewEvento(evento);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No value");
            }
        }

        //upload de foto
        /*[HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                //arquivo que vem da requisicao
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Fotos");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, fileName.Replace("\"", " ").Trim());

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No value");
            }

            return BadRequest();
        }*/

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Evento evento)
        {
            _srEvento.UpdateEvento(evento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Evento evento = await _srEvento.GetEventoByIdAsync(id);
            if (evento == null) return NotFound();
            _srEvento.DeleteEvento(evento);
            return Ok();
        }
    }
}