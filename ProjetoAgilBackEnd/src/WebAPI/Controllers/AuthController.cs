using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Facades.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthFacade _authFacade;

        public AuthController(IAuthFacade authFacade)
        {
            _authFacade = authFacade;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] User user)
        {
            if(user == null)
            {
                return NotFound(new { message = "usuário inválido" });
            }
            var token = _authFacade.GerarToken(user);
            user.Senha = "";
            return new
            {
                user = user,
                token = token
            };

        }
        [HttpGet]
        [Route("teste")]
        [AllowAnonymous]
        public string Teste() => "Teste sem login";


        [HttpGet]
        [Route("teste2")]
        [Authorize()]
        public string Teste2() => $"Teste logado {User.Identity.Name}";
    }
}
