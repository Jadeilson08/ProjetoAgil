using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Facades.Interface;
using WebAPI.Models;
using WebAPI.Services.Interface;

namespace WebAPI.Facades
{
    public class AuthFacade : IAuthFacade
    {
        private readonly IAuthService _authService;
        public AuthFacade(IAuthService authService)
        {
            _authService = authService;
        }
        public string GerarToken(User user)
        {
            return _authService.GerarToken(user);
        }
    }
}
